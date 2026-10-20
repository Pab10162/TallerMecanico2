using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// RESPONSABILIDAD: Leer y escribir vehículos en la tabla Vehiculos, incluida la búsqueda por DNI del propietario.
    /// POR QUÉ EXISTE: Concentra el acceso a datos de vehículos; delega en DAL_Cliente la búsqueda del propietario para no duplicar esa consulta.
    /// QUÉ NO HACE: No arma reglas de negocio ni mantiene conexiones abiertas más tiempo del necesario (implementa IDisposable).
    /// </summary>
    public class DAL_Vehiculo : IDisposable
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private Mapper_Vehiculo mapper = new Mapper_Vehiculo();

        private SqlConnection conexion;

        private bool disposed = false;

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public DAL_Vehiculo()
        {
            // Instanciamos la conexión al momento de crear la DAL
            conexion = ConexionDB.ObtenerConexion();
        }

        #endregion

        #region Operaciones públicas: consultas y comandos contra la base de datos

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

            AbrirSiCorresponde();
            using (SqlTransaction tran = conexion.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion, tran))
                    {
                        cmd.Parameters.AddRange(sp);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<BE_Vehiculo> obtenerVehiculos()
        {
            DAL_Cliente clienteDAL = new DAL_Cliente();

            List<BE_Vehiculo> listaVehiculos = new List<BE_Vehiculo>();
            string query = @"SELECT Marca, Modelo, Patente, Cedula, Cliente_DNI FROM Vehiculos";
            DataSet ds = new DataSet();

            // Usamos la conexión global de la clase
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            da.Fill(ds);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                string dniCliente = fila["Cliente_DNI"].ToString();
                BE_Cliente ClienteDNI = clienteDAL.obtenerClientePorDni(dniCliente);
                listaVehiculos.Add(mapper.ToBe(fila, ClienteDNI));
            }
            return listaVehiculos;
        }

        //Agregar sqlcommandBuilder
        public BE_Vehiculo obtenerVehiculoPorPatente(string patente)
        {
            DAL_Cliente clienteDAL = new DAL_Cliente();
            string query = @"SELECT Marca, Modelo, Patente, Cedula, Cliente_DNI FROM Vehiculos WHERE Patente = @Patente";
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
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

            AbrirSiCorresponde();
            using (SqlTransaction tran = conexion.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion, tran))
                    {
                        cmd.Parameters.AddRange(sp);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<BE_Vehiculo> obtenerVehiculosPorCliente(string dni)
        {
            DAL_Cliente clienteDAL = new DAL_Cliente();
            string query = @"SELECT Marca, Modelo, Patente, Cedula, Cliente_DNI FROM Vehiculos WHERE Cliente_DNI = @Cliente_DNI";
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            da.SelectCommand.Parameters.AddWithValue("@Cliente_DNI", dni);
            da.Fill(ds);

            BE_Cliente cliente = clienteDAL.obtenerClientePorDni(dni);
            List<BE_Vehiculo> vehiculos = new List<BE_Vehiculo>();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                vehiculos.Add(mapper.ToBe(fila, cliente));
            }
            return vehiculos;
        }

        #endregion

        #region Métodos auxiliares: apoyo interno que no forma parte de la interfaz pública

        private void AbrirSiCorresponde()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
        }

        #endregion

        #region Liberación de recursos (IDisposable)

        // --- Patrón IDisposable ---
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                // Liberamos los recursos administrados (la conexión a la base de datos)
                conexion?.Close();
                conexion?.Dispose();
            }
            disposed = true;
        }

        ~DAL_Vehiculo()
        {
            Dispose(false);
        }

        #endregion
    }
}