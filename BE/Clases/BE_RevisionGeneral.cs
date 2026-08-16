using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    public class BE_RevisionGeneral
    {
        public BE_RevisionGeneral(string descripcion, string observaciones, DateTime fecha, DateTime horario, BE_Turno turnoAsignado)
        {
            Descripcion = descripcion;
            Observaciones = observaciones;
            Fecha = fecha;
            Horario = horario;
            TurnoAsignado = turnoAsignado;
        }

        public string Descripcion {  get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
        public BE_Turno TurnoAsignado { get; set; }

    }
}
