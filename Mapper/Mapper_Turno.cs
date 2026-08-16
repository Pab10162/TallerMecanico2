using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
namespace Mapper
{
    public class Mapper_Turno
    {
        public BE_Turno ToBE(DataRow fila, BE_Cliente cliente, BE_Vehiculo vehiculo, Be_Usuario mecanico)
        {
            return new BE_Turno(
                iD_Turno : Convert.ToInt32(fila["ID_Turno"]),
                fecha: Convert.ToDateTime(fila["Fecha"]),
                horario: Convert.ToDateTime(fila["Horario"].ToString()),
                estado : fila["Estado"].ToString(),
                cliente : cliente,
                vehiculo : vehiculo,
                mecanico : mecanico
                );
        }
    }
}
