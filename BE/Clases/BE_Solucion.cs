using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    /// <summary>
    /// RESPONSABILIDAD: Describir la solución propuesta para un diagnóstico (tipo y descripción).
    /// POR QUÉ EXISTE: Un diagnóstico puede tener varias soluciones posibles; por eso es una clase aparte.
    /// QUÉ NO HACE: No calcula costos ni consume repuestos.
    /// </summary>
    public class BE_Solucion
    {
        #region Datos de la entidad: propiedades que la describen

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public BE_Diagnostico Diagnostico{ get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Solucion(string tipo, string descripcion, BE_Diagnostico diagnostico)
        {
            Tipo = tipo;
            Descripcion = descripcion;
            Diagnostico = diagnostico;
        }

        #endregion
    }
}
