using BE;
using BE.SubClases;
using System;
using System.Data;

namespace Mapper
{
    public class Mapper_Usuario
    {
        
        public Be_Usuario ToBE(DataRow fila)
        {
            string rol = fila["Rol"].ToString();
            Be_Usuario usuario = CrearPorRol(
                rol: rol,
                dni: fila["DNI"].ToString(),
                nombre: fila["Nombre"].ToString(),
                apellido: fila["Apellido"].ToString(),
                email: fila["Email"].ToString(),
                nombreUsuario: fila["NombreUsuario"].ToString(),
                bloqueado: (bool)fila["Bloqueado"]);
            usuario.Activo = Convert.ToBoolean(fila["Activo"]);
            return usuario;
        }

        
        public Be_Usuario ToBECompleto(DataRow fila)
        {

            string rol = fila["Rol"].ToString();

            switch (rol)
            {
                case "Administrador":
                    return new Be_Administrador(fila["Apellido"].ToString(), fila["Contraseña"].ToString(), fila["DNI"].ToString(), fila["Email"].ToString(), fila["Nombre"].ToString(), fila["NombreUsuario"].ToString(), fila["Idioma"].ToString(), (bool)fila["Bloqueado"], (bool)fila["Activo"], rol);
                case "Mecanico":
                    return new Be_Mecanico(fila["Apellido"].ToString(), fila["Contraseña"].ToString(), fila["DNI"].ToString(), fila["Email"].ToString(), fila["Nombre"].ToString(), fila["NombreUsuario"].ToString(), fila["Idioma"].ToString(), (bool)fila["Bloqueado"], (bool)fila["Activo"], rol);
                case "Cajero":
                    return new Be_Cajero(fila["Apellido"].ToString(), fila["Contraseña"].ToString(), fila["DNI"].ToString(), fila["Email"].ToString(), fila["Nombre"].ToString(), fila["NombreUsuario"].ToString(), fila["Idioma"].ToString(), (bool)fila["Bloqueado"], (bool)fila["Activo"], rol);
                case "Jefe de Taller":
                    return new Be_JefeTaller(fila["Apellido"].ToString(), fila["Contraseña"].ToString(), fila["DNI"].ToString(), fila["Email"].ToString(), fila["Nombre"].ToString(), fila["NombreUsuario"].ToString(), fila["Idioma"].ToString(), (bool)fila["Bloqueado"], (bool)fila["Activo"], rol);
                case "Recepcionista":
                    return new Be_Recepcionista(fila["Apellido"].ToString(), fila["Contraseña"].ToString(), fila["DNI"].ToString(), fila["Email"].ToString(), fila["Nombre"].ToString(), fila["NombreUsuario"].ToString(), fila["Idioma"].ToString(), (bool)fila["Bloqueado"], (bool)fila["Activo"], rol);
                default:
                    throw new Exception("Rol no reconocido: " + rol);
            }
        }

        private Be_Usuario CrearPorRol(string rol, string dni, string nombre, string apellido,
                                        string email, string nombreUsuario, bool bloqueado)
        {
            switch (rol)
            {
                case "Administrador":
                    return new Be_Administrador(dni, nombre, apellido, email, nombreUsuario, rol, bloqueado);
                case "Mecanico":
                    return new Be_Mecanico(dni, nombre, apellido, email, nombreUsuario, rol, bloqueado);
                case "Cajero":
                    return new Be_Cajero(dni, nombre, apellido, email, nombreUsuario, rol, bloqueado);
                case "Jefe de Taller":
                    return new Be_JefeTaller(dni, nombre, apellido, email, nombreUsuario, rol, bloqueado);
                case "Recepcionista":
                    return new Be_Recepcionista(dni, nombre, apellido, email, nombreUsuario, rol, bloqueado);
                default:
                    throw new Exception("Rol no existente");
            }
        }
    }
}