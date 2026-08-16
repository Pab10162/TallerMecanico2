using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    public class BE_BitacoraEvento
    {
        public BE_BitacoraEvento(DateTime fecha, DateTime horario, Be_Usuario usuario, string evento)
        {
            Fecha = fecha;
            Horario = horario;
            Usuario = usuario;
            Evento = evento;
        }

        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
        public Be_Usuario Usuario { get; set; }
        public string Evento { get; set; }
    }
}
