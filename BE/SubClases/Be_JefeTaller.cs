using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.SubClases
{
    /// <summary>
    /// RESPONSABILIDAD: Representar al jefe de taller (asigna mecánicos y supervisa).
    /// POR QUÉ EXISTE: El rol determina qué menús ve el usuario; cada rol es un tipo propio para poder preguntar "usuario is Be_JefeTaller" sin comparar strings.
    /// QUÉ NO HACE: No tiene comportamiento propio todavía: hoy solo distingue el tipo. Si un rol necesitara reglas particulares, vivirían acá.
    /// </summary>
    public class Be_JefeTaller : Be_Usuario
    {
        public Be_JefeTaller(string dni, string nombre, string apellido, string email,
                             string nombreusuario, string rol, bool bloq)
            : base(dni, nombre, apellido, email, nombreusuario, rol, bloq) { }

        public Be_JefeTaller(string apellido, string contraseña, string dni, string email,
                             string nombre, string nombreUsuario, string idioma,
                             bool bloqueado, bool activo, string rol)
            : base(apellido, contraseña, dni, email, nombre, nombreUsuario, idioma, bloqueado, activo, rol) { }
    }
}
