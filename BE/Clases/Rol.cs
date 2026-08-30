using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    public class Rol
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsFamilia { get; set; }
        public List<Rol> Hijos { get; set; }
        public Rol(string codigo, string nombre, bool esFamilia)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsFamilia = esFamilia;
            Hijos = new List<Rol>();
        }

        
    }
}
