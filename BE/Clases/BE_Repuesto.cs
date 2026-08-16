using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    public class BE_Repuesto
    {
        public BE_Repuesto(string descripcion, int cantidad, bool disponibilidad)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            Disponibilidad = disponibilidad;
        }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public bool Disponibilidad { get; set; } 
    }
}
