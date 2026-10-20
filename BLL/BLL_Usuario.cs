using BE;
using BE.Clases;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// RESPONSABILIDAD: Aplicar las reglas de negocio de usuarios: unicidad del nombre, login, bloqueo a los 3 intentos fallidos y cambio de contraseña.
    /// POR QUÉ EXISTE: Es la capa donde viven las decisiones; la UI solo pide y la DAL solo guarda.
    /// QUÉ NO HACE: No arma SQL ni dibuja pantallas. Publica el evento accionRealizada para que la bitácora se entere sin acoplarse.
    /// </summary>
    public class BLL_Usuario : IABM<Be_Usuario>, IDisposable
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private DAL_Usuario dal = new DAL_Usuario();

        public event AccionRealizadaHandler accionRealizada;

        #endregion

        #region Operaciones públicas: reglas de negocio que expone a la UI

        // --- IABM<Be_Usuario> ---
        public void Alta(Be_Usuario usuario)
        {
            if (dal.ObtenerPorNombreUsuario(usuario.NombreUsuario) != null)
                throw new Exception("Nombre de usuario ya existente");

            dal.CrearUsuario(usuario);
            accionRealizada?.Invoke($"Se creo al usuario: {usuario.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Baja(Be_Usuario usuario)
        {
            dal.EliminarUsuario(usuario);
            accionRealizada?.Invoke($"Se dio de baja al usuario: {usuario.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Modificacion(Be_Usuario usuario)
        {
            dal.ActualizarUsuario(usuario);
            accionRealizada?.Invoke($"Se actualizo dato del usuario: {usuario.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public List<Be_Usuario> ObtenerTodos()
        {
            return dal.ObtenerUsuarios();
        }

        public void CambiarPassword(string contraActual, string nuevaContra)
        {
            Be_Usuario usuario = SessionManager.GetInstance().UsuarioActual;
            string contraActualEncriptada = CryptoManager.Encriptar(contraActual);
            if (contraActualEncriptada == usuario.Contraseña)
            {
                string contraseñaNueva = CryptoManager.Encriptar(nuevaContra);
                dal.ActualizarContraseña(usuario.DNI, contraseñaNueva);
                usuario.Contraseña = contraseñaNueva; 
                accionRealizada?.Invoke("Se cambió la contraseña", usuario);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(nuevaContra))
                    throw new Exception("La nueva contraseña no puede estar vacía");
                throw new Exception("La contraseña actual no es correcta");
            }
        }

        public void Login(string nombreUsuario, string contraseña)
        {
            string contraseñaEncriptada = CryptoManager.Encriptar(contraseña);
            Be_Usuario usuarioEncontrado = dal.ObtenerPorNombreUsuario(nombreUsuario);

            if (usuarioEncontrado == null)
                throw new Exception("Nombre de usuario no existe");

            if (usuarioEncontrado.Bloqueado == true)
                throw new Exception("El usuario que intenta loguear se encuentra bloqueado");

            // Reflexión: la contraseña nunca se compara en texto plano; se cifra la ingresada y se comparan los hashes.
            if (contraseñaEncriptada != usuarioEncontrado.Contraseña)
            {
                var controlInt = ControlIntentos.GetInstance();
                controlInt.RegistrarIntentos(usuarioEncontrado.NombreUsuario);

                // Regla de negocio: al tercer intento fallido se bloquea la cuenta (queda guardado en la base, sobrevive al reinicio).
                if (controlInt.ObtenerCantidadIntentos(usuarioEncontrado.NombreUsuario) == 3)
                {
                    usuarioEncontrado.Bloqueado = true;
                    dal.ActualizarUsuario(usuarioEncontrado);
                    throw new Exception("Demasiados intentos fallidos, su usuario ha sido bloqueado");
                }
                throw new Exception("Las contraseñas no coinciden");
            }

            ControlIntentos.GetInstance().ResetearIntentos(usuarioEncontrado.NombreUsuario);
            SessionManager.GetInstance().Login(usuarioEncontrado);
            BE_BitacoraEvento evento = new BE_BitacoraEvento(DateTime.Now, DateTime.Now, SessionManager.GetInstance().UsuarioActual, "Inicio de sesion");
            new DAL_BitacoraEvento().RegistrarEvento(evento);
            accionRealizada?.Invoke("Inicio de sesion", SessionManager.GetInstance().UsuarioActual);
        }

        public void Logout()
        {
            SessionManager.GetInstance().Logout();
        }

        #endregion

        #region Liberación de recursos (IDisposable)

        // --- IDisposable: propaga la liberación hacia el DAL ---
        public void Dispose()
        {
            dal?.Dispose();
        }

        #endregion
    }
}