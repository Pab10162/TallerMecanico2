using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    /// <summary>
    /// RESPONSABILIDAD: Representar un evento auditable: cuándo ocurrió, quién lo hizo y qué hizo.
    /// POR QUÉ EXISTE: La bitácora es un requisito de seguridad; cada acción importante genera uno de estos objetos.
    /// QUÉ NO HACE: No decide cuándo registrar un evento (lo hace el Observer en Inicio) ni cómo guardarlo (DAL_BitacoraEvento).
    /// </summary>
    public class BE_BitacoraEvento
    {
        #region Datos de la entidad: propiedades que la describen

        public DateTime Fecha { get; set; }

        public DateTime Horario { get; set; }

        public Be_Usuario Usuario { get; set; }

        public string Evento { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_BitacoraEvento(DateTime fecha, DateTime horario, Be_Usuario usuario, string evento)
        {
            Fecha = fecha;
            Horario = horario;
            Usuario = usuario;
            Evento = evento;
        }

        #endregion
    }
}
