using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    /// <summary>
    /// RESPONSABILIDAD: Representar un repuesto con su descripción, cantidad y disponibilidad.
    /// POR QUÉ EXISTE: La reparación depende de que haya stock; esta clase es el dato que se consulta.
    /// QUÉ NO HACE: No descuenta stock ni lo repone: eso será lógica de BLL/DAL.
    /// </summary>
    public class BE_Repuesto
    {
        #region Datos de la entidad: propiedades que la describen

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public bool Disponibilidad { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Repuesto(string descripcion, int cantidad, bool disponibilidad)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            Disponibilidad = disponibilidad;
        }

        #endregion
    }
}
