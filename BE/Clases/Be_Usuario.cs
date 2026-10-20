using System;
namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Modelar a una persona que puede iniciar sesión: DNI, credenciales, rol, idioma y estado (bloqueado / activo).
    /// POR QUÉ EXISTE: Todos los roles comparten estos datos; la clase abstracta evita repetirlos y permite que el resto del sistema trabaje con "un usuario" sin saber cuál rol es.
    /// QUÉ NO HACE: No sabe cifrar contraseñas, no consulta la base ni decide permisos: eso es de CryptoManager, DAL_Usuario y la UI/Rol.
    /// </summary>
    public abstract class Be_Usuario
    {
        #region Datos de la entidad: propiedades que la describen

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

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

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

        #endregion

        #region Operaciones públicas: comportamiento propio de la entidad

        public override string ToString()
        {
            return $"{Nombre} - {Apellido}";
            ;
        }

        #endregion
    }
}