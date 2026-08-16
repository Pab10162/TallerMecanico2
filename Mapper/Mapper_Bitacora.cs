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
