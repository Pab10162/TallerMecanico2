using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class DAL_Vehiculo
    {
        private Mapper_Vehiculo mapper = new Mapper_Vehiculo();

        public void CrearVehiculo(BE_Vehiculo vehiculo)
        {
            string query = @"INSERT INTO Vehiculos
                    (Marca, Modelo, Patente, Cedula, Cliente_DNI)
                    VALUES (@Marca, @Modelo, @Patente, @Cedula, @Cliente_DNI)";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Marca", vehiculo.Marca),
                new SqlParameter("@Modelo", vehiculo.Modelo),
                new SqlParameter("@Patente", vehiculo.Patente),
                new SqlParameter("@Cedula", vehiculo.Cedula),
                new SqlParameter("@Cliente_DNI", vehiculo.Cliente.DNI)
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

        public List<BE_Vehiculo> obtenerVehiculos()
        {
            DAL_Cliente clienteDAL = new DAL_Cliente();

            List<BE_Vehiculo> listaVehiculos = new List<BE_Vehiculo>();
            string query = @"SELECT Marca, Modelo, Patente, Cedula, Cliente_DNI FROM Vehiculos";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.Fill(ds);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                string dniCliente = fila["Cliente_DNI"].ToString();
                BE_Cliente ClienteDNI = clienteDAL.obtenerClientePorDni(dniCliente);
                listaVehiculos.Add(mapper.ToBe(fila, ClienteDNI));
            }
            return listaVehiculos;
        }

        public BE_Vehiculo obtenerVehiculoPorPatente(string patente)
        {
            DAL_Cliente clienteDAL = new DAL_Cliente();
            string query = @"SELECT Marca, Modelo, Patente, Cedula, Cliente_DNI FROM Vehiculos WHERE Patente = @Patente";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.SelectCommand.Parameters.AddWithValue("@Patente", patente);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                string dniCliente = fila["Cliente_DNI"].ToString();
                BE_Cliente ClienteDNI = clienteDAL.obtenerClientePorDni(dniCliente);
                return mapper.ToBe(fila, ClienteDNI);
            }
            return null;
        }

        public void ActualizarVehiculo(BE_Vehiculo vehiculo)
        {
            string query = @"UPDATE Vehiculos SET Marca = @Marca, Modelo = @Modelo, Cedula = @Cedula, 
                            Cliente_DNI = @Cliente_DNI WHERE Patente = @Patente";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Marca", vehiculo.Marca),
                new SqlParameter("@Modelo", vehiculo.Modelo),
                new SqlParameter("@Patente", vehiculo.Patente),
                new SqlParameter("@Cedula", vehiculo.Cedula),
                new SqlParameter("@Cliente_DNI", vehiculo.Cliente.DNI)
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