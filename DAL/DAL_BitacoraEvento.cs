using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;
using BE.Clases;
using Mapper;

namespace DAL
{
    public class DAL_BitacoraEvento
    {

        public void RegistrarEvento(BE_BitacoraEvento evento)
        {
            string query = "INSERT INTO BitacoraEventos(Fecha, Horario, DNI_Usuario, Evento) VALUES (@Fecha, @Horario, @DNI_Usuario, @Evento)";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Fecha", evento.Fecha),
                new SqlParameter("@Horario", evento.Horario.TimeOfDay),
                new SqlParameter("@DNI_Usuario", evento.Usuario.DNI),
                new SqlParameter("@Evento", evento.Evento)
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

        public List<BE_BitacoraEvento> ObtenerEventos()
        {
            List<BE_BitacoraEvento> listaEventos = new List<BE_BitacoraEvento>();

            DAL_Usuario usuarioDAL = new DAL_Usuario();

            string query = "SELECT * FROM BitacoraEventos";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.Fill(ds);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                string dniUsuario = fila["DNI_Usuario"].ToString();
                Be_Usuario UsuariDNI = usuarioDAL.ObtenerPorDNI(dniUsuario);

                listaEventos.Add(fila, UsuariDNI);
            }
            return listaEventos;
        }
    }
}
