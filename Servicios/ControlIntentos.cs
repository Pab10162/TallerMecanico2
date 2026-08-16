using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    public class ControlIntentos
    {
        private static ControlIntentos Instancia; 
        public List<IntentosFallidos> CantFallidos = new List<IntentosFallidos>();
        public static ControlIntentos GetInstance()
        {
            if(Instancia == null)
            {
                return Instancia = new ControlIntentos();
            }
            return Instancia;
        }
        private ControlIntentos() { }

        public void RegistrarIntentos(string nombreUsuario)
        {
            if (CantFallidos.Any(i => i.NombreUsuario == nombreUsuario))
            {
                var encontrado = CantFallidos.FirstOrDefault(i => i.NombreUsuario == nombreUsuario);
                encontrado.Cantidad++;
            }
            else
            {
                CantFallidos.Add(new IntentosFallidos(nombreUsuario, 1));
            }
        }

        public void ResetearIntentos(string nombreUsuario)
        {
            if (CantFallidos.Any(i => i.NombreUsuario == nombreUsuario))
            {
                var encontrado = CantFallidos.FirstOrDefault(i => i.NombreUsuario == nombreUsuario);
                encontrado.Cantidad = 0;
            }
        }
        public int ObtenerCantidadIntentos(string nombreUsuario)
        {
            var encontrado = CantFallidos.FirstOrDefault(i => i.NombreUsuario == nombreUsuario);
            if (encontrado != null)
            {
                return encontrado.Cantidad;
            }
            return 0;
        }
    }
}
