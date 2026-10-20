using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Guardar los datos de contacto de una persona que trae su vehículo al taller (DNI como identificador).
    /// POR QUÉ EXISTE: Cliente y Usuario son personas distintas: el cliente no inicia sesión, por eso no hereda de Be_Usuario.
    /// QUÉ NO HACE: No valida el DNI ni se persiste a sí mismo; la validación está en la BLL/UI y el acceso a datos en DAL_Cliente.
    /// </summary>
    public class BE_Cliente
    {
        #region Datos de la entidad: propiedades que la describen

        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Direccion {  get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Cliente() {}

        public BE_Cliente(string dni, string nombre, string apellido, string telefono, string direccion)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Direccion = direccion;
        }

        #endregion

        #region Operaciones públicas: comportamiento propio de la entidad

        public override string ToString()
        {
            return $"{DNI} - {Nombre} {Apellido}";
        }

        #endregion
    }
}
