using BE;
using System.Data;

namespace Mapper
{
    /// <summary>
    /// RESPONSABILIDAD: Traducir una fila de Vehiculos a BE_Vehiculo, recibiendo ya resuelto el cliente propietario.
    /// POR QUÉ EXISTE: Evita que el mapper consulte la base: el DAL le entrega el cliente.
    /// QUÉ NO HACE: No busca al cliente por su cuenta.
    /// </summary>
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