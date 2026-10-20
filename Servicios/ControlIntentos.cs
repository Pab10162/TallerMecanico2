using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    /// <summary>
    /// RESPONSABILIDAD: Contar los intentos fallidos de login por usuario (Singleton).
    /// POR QUÉ EXISTE: El conteo debe sobrevivir entre varios intentos de login durante la ejecución, por eso es una única instancia.
    /// QUÉ NO HACE: No bloquea al usuario: BLL_Usuario decide el bloqueo cuando el contador llega a 3. El conteo se pierde al cerrar la aplicación.
    /// </summary>
    public class ControlIntentos
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private static ControlIntentos Instancia;

        public List<IntentosFallidos> CantFallidos = new List<IntentosFallidos>();

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        private ControlIntentos() { }

        #endregion

        #region Operaciones públicas: servicio transversal usado por todas las capas

        public static ControlIntentos GetInstance()
        {
            if(Instancia == null)
            {
                return Instancia = new ControlIntentos();
            }
            return Instancia;
        }

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

        #endregion
    }
}
