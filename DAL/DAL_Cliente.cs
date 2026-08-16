using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class DAL_Cliente
    {
        public void CrearCliente(BE_Cliente cliente)
        {
            string query = @"INSERT INTO Clientes 
                (DNI, Nombre, Apellido, Telefono, Direccion)
                VALUES (@DNI, @Nombre, @Apellido, @Telefono, @Direccion)";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter(@"DNI", cliente.DNI),
                new SqlParameter(@"Nombre", cliente.Nombre),
                new SqlParameter(@"Apellido", cliente.Apellido),
                new SqlParameter(@"Telefono", cliente.Telefono),
                new SqlParameter(@"Direccion", cliente.Direccion)
            };
            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Mapper_Cliente mapper = new Mapper_Cliente();

        public List<BE_Cliente> ObtenerClientes()
        {
            List<BE_Cliente> listaCliente = new List<BE_Cliente>();
            string query = @"SELECT DNI, Nombre, Apellido, Telefono, Direccion FROM Clientes";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.Fill(ds);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                listaCliente.Add(mapper.ToBE(fila));
            }
            return listaCliente;
        }

        public BE_Cliente obtenerClientePorDni(string dni)
        {
            string query = @"SELECT DNI, Nombre, Apellido, Telefono, Direccion FROM Clientes
                            WHERE DNI = @DNI";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.SelectCommand.Parameters.AddWithValue("@DNI", dni);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return mapper.ToBE(ds.Tables[0].Rows[0]);
            }
            return null;
        }

        public void ActualizarCliente(BE_Cliente cliente)
        {
            string query = @"UPDATE Clientes SET  Nombre = @Nombre, Apellido = @Apellido,
                            Telefono = @Telefono, Direccion = @Direccion WHERE DNI = @DNI";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter(@"DNI", cliente.DNI),
                new SqlParameter(@"Nombre", cliente.Nombre),
                new SqlParameter(@"Apellido", cliente.Apellido),
                new SqlParameter(@"Telefono", cliente.Telefono),
                new SqlParameter(@"Direccion", cliente.Direccion)
            };

            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sp);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}