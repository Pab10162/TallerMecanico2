using BE;
using BE.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    /// <summary>
    /// RESPONSABILIDAD: Traducir una fila de la bitácora a BE_BitacoraEvento.
    /// POR QUÉ EXISTE: Mismo criterio que el resto de mappers: conversión fila-objeto aislada.
    /// QUÉ NO HACE: No accede a la base.
    /// </summary>
    public class Mapper_Bitacora 
    {
        public BE_BitacoraEvento ToBE(DataRow fila, Be_Usuario usuario)
        {
            return new BE_BitacoraEvento(
                fecha: Convert.ToDateTime(fila["Fecha"]),
                horario: Convert.ToDateTime(fila["Horario"].ToString()),
                usuario: usuario,
                evento: fila["Evento"].ToString());
        }
    }
}
