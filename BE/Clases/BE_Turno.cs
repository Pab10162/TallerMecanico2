using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Representar una reserva de fecha y horario para atender un vehículo, con su estado y el mecánico asignado.
    /// POR QUÉ EXISTE: Es la entidad central del PN1: de ella cuelgan la revisión, el diagnóstico y el cobro del PN2.
    /// QUÉ NO HACE: No calcula horarios libres ni valida solapamientos (BLL_Turno) ni escribe en la base (DAL_Turno).
    /// </summary>
    public class BE_Turno
    {
        #region Datos de la entidad: propiedades que la describen

        public int ID_Turno {  get; set; }

        public DateTime Fecha {  get; set; }

        public DateTime Horario { get; set; }

        public string Estado { get; set; }

        public BE_Cliente Cliente { get; set; }

        public BE_Vehiculo vehiculo { get; set; }

        public Be_Usuario Mecanico { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Turno(DateTime fecha, DateTime horario, string estado, BE_Cliente cliente, BE_Vehiculo vehiculo)
        : this(fecha, horario, estado, cliente, vehiculo, null)
        {
        }

        public BE_Turno(DateTime fecha, DateTime horario, string estado, BE_Cliente cliente, BE_Vehiculo vehiculo, Be_Usuario mecanico)
        {
            Fecha = fecha;
            Horario = horario;
            Estado = estado;
            Cliente = cliente;
            this.vehiculo = vehiculo;
            Mecanico = mecanico;
        }

        public BE_Turno(int iD_Turno, DateTime fecha, DateTime horario, string estado, BE_Cliente cliente, BE_Vehiculo vehiculo, Be_Usuario mecanico)
        {
            ID_Turno = iD_Turno;
            Fecha = fecha;
            Horario = horario;
            Estado = estado;
            Cliente = cliente;
            this.vehiculo = vehiculo;
            Mecanico = mecanico;
        }

        #endregion
    }
}
