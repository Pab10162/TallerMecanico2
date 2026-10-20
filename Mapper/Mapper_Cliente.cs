using BE;
using System.Data;

namespace Mapper
{
    /// <summary>
    /// RESPONSABILIDAD: Traducir una fila de Clientes a BE_Cliente.
    /// POR QUÉ EXISTE: Mantiene la conversión tabla-objeto en un único lugar.
    /// QUÉ NO HACE: No accede a la base.
    /// </summary>
    public class Mapper_Cliente
    {
        public BE_Cliente ToBE(DataRow fila)
        {
            return new BE_Cliente(
                dni: fila["DNI"].ToString(),
                nombre: fila["Nombre"].ToString(),
                apellido: fila["Apellido"].ToString(),
                telefono: fila["Telefono"].ToString(),
                direccion: fila["Direccion"].ToString());
        }
    }
}