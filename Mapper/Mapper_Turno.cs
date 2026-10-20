using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
namespace Mapper
{
    /// <summary>
    /// RESPONSABILIDAD: Traducir una fila de Turnos a BE_Turno, recibiendo cliente, vehículo y mecánico ya resueltos.
    /// POR QUÉ EXISTE: Un turno referencia varias entidades; resolverlas es trabajo del DAL, el mapper solo ensambla.
    /// QUÉ NO HACE: No consulta la base.
    /// </summary>
    public class Mapper_Turno
    {
        public BE_Turno ToBE(DataRow fila, BE_Cliente cliente, BE_Vehiculo vehiculo, Be_Usuario mecanico)
        {
            DateTime fecha = Convert.ToDateTime(fila["Fecha"]);
            TimeSpan horaSpan = (TimeSpan)fila["Horario"];
            DateTime horarioCompleto = fecha.Date + horaSpan;

            return new BE_Turno(
                iD_Turno: Convert.ToInt32(fila["ID_Turno"]),
                fecha: fecha,
                horario: horarioCompleto,
                estado: fila["Estado"].ToString(),
                cliente: cliente,
                vehiculo: vehiculo,
                mecanico: mecanico
                );
        }
    }
}
