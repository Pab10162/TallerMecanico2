using System;
namespace BE
{
    public abstract class Be_Usuario
    {
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string idioma { get; set; }
        public bool Bloqueado { get; set; }
        public bool Activo { get; set; }
        public string Rol { get; set; }

        public Be_Usuario() { }

        public Be_Usuario(string dni, string nombre, string apellido, string email, string nombreusuario, string rol, bool bloq)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            NombreUsuario = nombreusuario;
            Rol = rol;
            Bloqueado = bloq;
        }

        public Be_Usuario(string apellido, string contraseña, string dni, string email, string nombre, string nombreUsuario, string idioma, bool bloqueado, bool activo, string rol)
        {
            Apellido = apellido;
            Contraseña = contraseña;
            DNI = dni;
            Email = email;
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
            this.idioma = idioma;
            Bloqueado = bloqueado;
            Activo = activo;
            Rol = rol;
        }
    }
}