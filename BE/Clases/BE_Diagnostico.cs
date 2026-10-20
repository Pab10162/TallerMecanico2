using BE.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Describir el problema detectado: sistema afectado, descripción y nivel de urgencia.
    /// POR QUÉ EXISTE: Es el resultado técnico de la revisión y la base sobre la que se proponen soluciones.
    /// QUÉ NO HACE: No propone soluciones (BE_Solucion) ni decide la urgencia: solo la guarda.
    /// </summary>
    public class BE_Diagnostico
    {
        #region Datos de la entidad: propiedades que la describen

        public string SistemaAfectado {  get; set; }

        public string Descripcion { get; set; }

        public BE_Tarea TareaAsignada { get; set; }

        public Urgencia Urgencia { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Diagnostico(string sistemaAfectado, string descripcion, Urgencia urgencia, BE_Tarea tareaasignada)
        {
            SistemaAfectado = sistemaAfectado;
            Descripcion = descripcion;
            this.Urgencia = urgencia;
            this.TareaAsignada = tareaasignada;
        }

        #endregion
    }
}
