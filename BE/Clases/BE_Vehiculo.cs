using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Vehiculo
    {
        public string Marca { get; set; }   
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public BE_Cliente  Cliente { get; set; }
        public string Cedula {  get; set; }
        public BE_Vehiculo(string marca, string modelo, string patente, string cedula, BE_Cliente cliente)
        {
            Marca = marca;
            Modelo = modelo;
            Patente = patente;
            Cedula = cedula;
            Cliente = cliente;
        }
        public BE_Vehiculo(){}

        public override string ToString()
        {
            return $"{Patente} - {Marca} - {Modelo}";
        }
    }
}
