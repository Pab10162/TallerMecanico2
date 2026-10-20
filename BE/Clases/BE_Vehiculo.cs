using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Representar un vehículo identificado por su patente y asociado a un cliente propietario.
    /// POR QUÉ EXISTE: Un cliente puede tener varios vehículos y los turnos se asignan a un vehículo concreto, no a la persona.
    /// QUÉ NO HACE: No sabe buscar los vehículos de un cliente: eso lo resuelve DAL_Vehiculo.
    /// </summary>
    public class BE_Vehiculo
    {
        #region Datos de la entidad: propiedades que la describen

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Patente { get; set; }

        public BE_Cliente  Cliente { get; set; }

        public string Cedula {  get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Vehiculo(string marca, string modelo, string patente, string cedula, BE_Cliente cliente)
        {
            Marca = marca;
            Modelo = modelo;
            Patente = patente;
            Cedula = cedula;
            Cliente = cliente;
        }

        public BE_Vehiculo(){}

        #endregion

        #region Operaciones públicas: comportamiento propio de la entidad

        public override string ToString()
        {
            return $"{Patente} - {Marca} - {Modelo}";
        }

        #endregion
    }
}
