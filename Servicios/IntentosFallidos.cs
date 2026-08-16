using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class IntentosFallidos
    {
        public IntentosFallidos(string nombreUsuario, int cantidad)
        {
            NombreUsuario = nombreUsuario;
            Cantidad = cantidad;
        }

        public string NombreUsuario { get; set; }
        public int Cantidad { get; set; }

    }
}
