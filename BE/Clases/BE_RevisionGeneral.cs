using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    /// <summary>
    /// RESPONSABILIDAD: Registrar la revisión inicial del vehículo asociada a un turno (descripción y observaciones).
    /// POR QUÉ EXISTE: Es el primer paso del PN2: sin revisión general no hay diagnóstico.
    /// QUÉ NO HACE: Todavía no tiene persistencia ni BLL: pertenece a la Fase 1 del roadmap del PN2.
    /// </summary>
    public class BE_RevisionGeneral
    {
        #region Datos de la entidad: propiedades que la describen

        public string Descripcion {  get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Horario { get; set; }

        public BE_Turno TurnoAsignado { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_RevisionGeneral(string descripcion, string observaciones, DateTime fecha, DateTime horario, BE_Turno turnoAsignado)
        {
            Descripcion = descripcion;
            Observaciones = observaciones;
            Fecha = fecha;
            Horario = horario;
            TurnoAsignado = turnoAsignado;
        }

        #endregion
    }
}
