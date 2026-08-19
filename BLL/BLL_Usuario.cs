using System;
using System.Collections.Generic;
using BE;        
using DAL;       
using Servicios; 

namespace BLL
{
    public class BLL_Usuario
    {
        private DAL_Usuario dal = new DAL_Usuario();
        public event AccionRealizadaHandler accionRealizada;
        public void CrearUsuario(Be_Usuario usuario)
        {
            if (dal.ObtenerPorNombreUsuario(usuario.NombreUsuario) != null)
            {
                throw new Exception("Nombre de usuario ya existente");
            }
            dal.CrearUsuario(usuario);
            accionRealizada?.Invoke($"Se creo al usuario: {usuario.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Login(string nombreUsuario, string contraseña)
        {
            string contraseñaEncriptadad = CryptoManager.Encriptar(contraseña);

            Be_Usuario usuarioEncontrado = dal.ObtenerPorNombreUsuario(nombreUsuario);

            if ( usuarioEncontrado == null)
            {
                throw new Exception("Nombre de usuario no existe");
            }

            if (usuarioEncontrado.Bloqueado == true)
            {
                throw new Exception("El usuario que intenta loguear se encuentra bloqueado");
            }

            if (contraseñaEncriptadad != usuarioEncontrado.Contraseña)
            {
                var ControlInt = ControlIntentos.GetInstance();
                ControlInt.RegistrarIntentos(usuarioEncontrado.NombreUsuario);

                

                 if(ControlInt.ObtenerCantidadIntentos(usuarioEncontrado.NombreUsuario) == 3)
                {
                    usuarioEncontrado.Bloqueado = true;
                    dal.ActualizarUsuario(usuarioEncontrado);
                    throw new Exception("Demasiados intentos fallidos, su usuario ha sido bloqueado");
                }
                throw new Exception("Las contraseñas no coinciden");
            }
            ControlIntentos.GetInstance().ResetearIntentos(usuarioEncontrado.NombreUsuario);

            SessionManager.GetInstance().Login(usuarioEncontrado);
            accionRealizada?.Invoke($"Inicio de sesion", SessionManager.GetInstance().UsuarioActual);
        }

        public List<Be_Usuario> obtenerUsuarios()
        {
            return dal.ObtenerUsuarios();
        }

        public void ActualizarUsuario(Be_Usuario usuario)
        {
            dal.ActualizarUsuario(usuario);
            accionRealizada?.Invoke($"Se actualizo dato del usuario: {usuario.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Logout()
        {
            SessionManager.GetInstance().Logout();
        }
    }
}
