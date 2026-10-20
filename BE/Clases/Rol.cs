using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    /// <summary>
    /// RESPONSABILIDAD: Modelar un permiso o una familia de permisos usando el patrón Composite (hoja o contenedor de otros roles).
    /// POR QUÉ EXISTE: Permite armar jerarquías de permisos y preguntar TienePermiso(código) sin distinguir si es una hoja o una familia.
    /// QUÉ NO HACE: Hoy no está conectado al menú: la visibilidad todavía se decide por tipo de usuario. Separar Familia/Patente es un pendiente del PN1.
    /// </summary>
    public class Rol
    {
        #region Datos de la entidad: propiedades que la describen

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public bool EsFamilia { get; set; }

        public List<Rol> Hijos { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public Rol(string codigo, string nombre, bool esFamilia)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsFamilia = esFamilia;
            Hijos = new List<Rol>();
        }

        #endregion

        #region Operaciones públicas: comportamiento propio de la entidad

        public bool TienePermiso(string codigo)
        {
            return Codigo == codigo;
        }

        public bool Contiene(string codigo)
        {
            foreach (Rol hijo in Hijos)
            {
                if (hijo.Codigo == codigo)
                    return true;
                if (hijo.EsFamilia && hijo.Contiene(codigo))
                    return true;
            }
            return false;
        }

        #endregion
    }
}
