using System;
using System.Collections.Generic;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class BLL_Usuario : IABM<Be_Usuario>, IDisposable
    {
        private DAL_Usuario dal = new DAL_Usuario();
        public event AccionRealizadaHandler accionRealizada;

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

        // --- Métodos propios (no forman parte del CRUD genérico) ---
        public void Login(string nombreUsuario, string contraseña)
        {
            string contraseñaEncriptada = CryptoManager.Encriptar(contraseña);
            Be_Usuario usuarioEncontrado = dal.ObtenerPorNombreUsuario(nombreUsuario);

            if (usuarioEncontrado == null)
                throw new Exception("Nombre de usuario no existe");

            if (usuarioEncontrado.Bloqueado == true)
                throw new Exception("El usuario que intenta loguear se encuentra bloqueado");

            if (contraseñaEncriptada != usuarioEncontrado.Contraseña)
            {
                var controlInt = ControlIntentos.GetInstance();
                controlInt.RegistrarIntentos(usuarioEncontrado.NombreUsuario);

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
            accionRealizada?.Invoke("Inicio de sesion", SessionManager.GetInstance().UsuarioActual);
        }

        public void Logout()
        {
            SessionManager.GetInstance().Logout();
        }

        // --- IDisposable: propaga la liberación hacia el DAL ---
        public void Dispose()
        {
            dal?.Dispose();
        }
    }
}