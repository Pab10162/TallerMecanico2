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
    /// <summary>
    /// RESPONSABILIDAD: Leer y escribir clientes en la tabla Clientes.
    /// POR QUÉ EXISTE: Mantiene el SQL fuera de la BLL y la UI.
    /// QUÉ NO HACE: No decide si un DNI es válido ni si el cliente ya existe: eso es de la BLL.
    /// </summary>
    public class DAL_Cliente : IDisposable
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private Mapper_Cliente mapper = new Mapper_Cliente();

        private SqlConnection conexion;

        private bool disposed = false;

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public DAL_Cliente()
        {
            conexion = ConexionDB.ObtenerConexion();
        }

        #endregion

        #region Operaciones públicas: consultas y comandos contra la base de datos

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

        public List<BE_Cliente> ObtenerClientes()
        {
            string query = @"SELECT DNI, Nombre, Apellido, Telefono, Direccion FROM Clientes";
            List<BE_Cliente> listaCliente = new List<BE_Cliente>();
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

        public void EliminarCliente(BE_Cliente cliente)
        {
            string query = "UPDATE Clientes SET Activo = 0 WHERE DNI = @DNI";

            AbrirSiCorresponde();
            using (SqlTransaction tran = conexion.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion, tran))
                    {
                        cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
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
                conexion?.Close();
                conexion?.Dispose();
            }
            disposed = true;
        }

        ~DAL_Cliente()
        {
            Dispose(false);
        }

        #endregion
    }
}