using BE.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Diagnostico
    {
        public BE_Diagnostico(string sistemaAfectado, string descripcion, Urgencia urgencia, BE_Tarea tareaasignada)
        {
            SistemaAfectado = sistemaAfectado;
            Descripcion = descripcion;
            this.Urgencia = urgencia;
            this.TareaAsignada = tareaasignada;
        }

        public string SistemaAfectado {  get; set; }
        public string Descripcion { get; set; }
        public BE_Tarea TareaAsignada { get; set; }
        public Urgencia Urgencia { get; set; }

    }
}
