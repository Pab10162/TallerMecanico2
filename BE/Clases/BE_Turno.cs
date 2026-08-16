using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Turno
    {
        public int ID_Turno {  get; set; }
        public DateTime Fecha {  get; set; }
        public DateTime Horario { get; set; }
        public string Estado { get; set; }
        public BE_Cliente Cliente { get; set; }
        public BE_Vehiculo vehiculo { get; set; }
        public Be_Usuario Mecanico { get; set; }
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
    }
}
