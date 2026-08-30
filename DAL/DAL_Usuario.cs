using BE;
using BE.SubClases;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Usuario : IDisposable
    {
        private Mapper_Usuario mapper = new Mapper_Usuario();
        private SqlConnection conexion;
        private bool disposed = false;

        public DAL_Usuario()
        {
            conexion = ConexionDB.ObtenerConexion();
        }

        public void CrearUsuario(Be_Usuario usuario)
        {
            string query =
            @"INSERT INTO Usuarios 
            (DNI, Nombre, Apellido, Email, Bloqueado, 
            NombreUsuario, Contraseña, Idioma, Rol, Activo) 
            VALUES (@DNI, @Nombre, @Apellido, @Email, @Bloqueado, 
            @NombreUsuario, @Contraseña, @Idioma, @Rol, @Activo)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@DNI", usuario.DNI),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Apellido", usuario.Apellido),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Bloqueado", usuario.Bloqueado),
                new SqlParameter("@Contraseña", usuario.Contraseña),
                new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
                new SqlParameter("@Idioma", usuario.idioma),
                new SqlParameter("@Rol", usuario.Rol),
                new SqlParameter("@Activo", usuario.Activo)
            };

            AbrirSiCorresponde();
            using (SqlTransaction tran = conexion.BeginTransaction())
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion, tran))
                    {
                        comando.Parameters.AddRange(parameters);
                        comando.ExecuteNonQuery();
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

        public List<Be_Usuario> ObtenerUsuarios()
        {
            string query = @"SELECT DNI, Nombre, Apellido, Email, NombreUsuario, Rol, Bloqueado, Activo FROM Usuarios";
            List<Be_Usuario> lista = new List<Be_Usuario>();
            DataSet ds = new DataSet();

            // Modo desconectado: adecuado para consultas masivas/listados
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            da.Fill(ds);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                lista.Add(mapper.ToBE(fila));
            }
            return lista;
        }

        public Be_Usuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            string query = @"SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return mapper.ToBECompleto(fila);
            }
            return null;
        }

        public Be_Usuario ObtenerPorDNI(string dni)
        {
            string query = @"SELECT * FROM Usuarios WHERE DNI = @DNI";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            da.SelectCommand.Parameters.AddWithValue("@DNI", dni);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return mapper.ToBECompleto(fila);
            }
            return null;
        }

        public void ActualizarUsuario(Be_Usuario usuario)
        {
            string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, " +
                            "Rol = @Rol, Activo = @Activo, Bloqueado = @Bloqueado WHERE DNI = @DNI";

            SqlParameter[] parameters =
            {
                new SqlParameter("@DNI", usuario.DNI),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Apellido", usuario.Apellido),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Bloqueado", usuario.Bloqueado),
                new SqlParameter("@Rol", usuario.Rol),
                new SqlParameter("@Activo", usuario.Activo)
            };

            AbrirSiCorresponde();
            using (SqlTransaction tran = conexion.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion, tran))
                    {
                        cmd.Parameters.AddRange(parameters);
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

        // Baja lógica: es más seguro que un DELETE porque no rompe
        // los turnos/tareas históricos que referencian a este usuario.
        public void EliminarUsuario(Be_Usuario usuario)
        {
            string query = "UPDATE Usuarios SET Activo = 0 WHERE DNI = @DNI";

            AbrirSiCorresponde();
            using (SqlTransaction tran = conexion.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion, tran))
                    {
                        cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
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

        private void AbrirSiCorresponde()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
        }

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

        ~DAL_Usuario()
        {
            Dispose(false);
        }
    }
}