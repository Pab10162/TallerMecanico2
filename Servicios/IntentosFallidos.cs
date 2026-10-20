using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    /// <summary>
    /// RESPONSABILIDAD: Guardar el par (nombre de usuario, cantidad de fallos).
    /// POR QUÉ EXISTE: Estructura mínima que ControlIntentos usa para llevar la cuenta.
    /// QUÉ NO HACE: No tiene lógica.
    /// </summary>
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
