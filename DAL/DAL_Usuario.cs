using BE;
using BE.SubClases;
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
    public class DAL_Usuario
    {
        private Mapper_Usuario mapper = new Mapper_Usuario();

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
                new SqlParameter(@"DNI", usuario.DNI),
                new SqlParameter(@"Nombre", usuario.Nombre),
                new SqlParameter(@"Apellido", usuario.Apellido),
                new SqlParameter(@"Email", usuario.Email),
                new SqlParameter(@"Bloqueado", usuario.Bloqueado),
                new SqlParameter(@"Contraseña", usuario.Contraseña),
                new SqlParameter(@"NombreUsuario", usuario.NombreUsuario),
                new SqlParameter("@Idioma", usuario.idioma),
                new SqlParameter("@Rol", usuario.Rol),
                new SqlParameter("@Activo", usuario.Activo)
            };
            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddRange(parameters);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Be_Usuario> ObtenerUsuarios()
        {
            string query = @"SELECT DNI, Nombre, Apellido, Email, NombreUsuario, Rol, Bloqueado, Activo FROM Usuarios";
            List<Be_Usuario> lista = new List<Be_Usuario>();
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
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
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
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
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
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
            string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Rol = @Rol, Activo = @Activo, Bloqueado = @Bloqueado WHERE DNI = @DNI";

            SqlParameter[] parameters =
            {
                new SqlParameter(@"DNI", usuario.DNI),
                new SqlParameter(@"Nombre", usuario.Nombre),
                new SqlParameter(@"Apellido", usuario.Apellido),
                new SqlParameter(@"Email", usuario.Email),
                new SqlParameter(@"Bloqueado", usuario.Bloqueado),
                new SqlParameter("@Rol", usuario.Rol),
                new SqlParameter("@Activo", usuario.Activo)
            };
            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}