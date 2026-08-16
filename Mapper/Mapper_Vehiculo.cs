using BE;
using System.Data;

namespace Mapper
{
    public class Mapper_Vehiculo
    {
        public BE_Vehiculo ToBe(DataRow fila, BE_Cliente cliente)
        {
            return new BE_Vehiculo(
                marca: fila["Marca"].ToString(),
                modelo: fila["Modelo"].ToString(),
                patente: fila["Patente"].ToString(),
                cedula: fila["Cedula"].ToString(),
                cliente: cliente);
        }
    }
}