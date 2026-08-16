using BE;
using System.Data;

namespace Mapper
{
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