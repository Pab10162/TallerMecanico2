using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Cliente
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion {  get; set; } 
        public BE_Cliente() {}
        public BE_Cliente(string dni, string nombre, string apellido, string telefono, string direccion)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"{DNI} - {Nombre} {Apellido}";
        }
    }
}
