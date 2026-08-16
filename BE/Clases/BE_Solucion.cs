using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    public class BE_Solucion
    {
        public BE_Solucion(string tipo, string descripcion, BE_Diagnostico diagnostico)
        {
            Tipo = tipo;
            Descripcion = descripcion;
            Diagnostico = diagnostico;
        }

        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public BE_Diagnostico Diagnostico{ get; set; }
    }
}
