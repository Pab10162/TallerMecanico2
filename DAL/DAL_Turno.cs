using BE;
using BE.SubClases;
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
    public class DAL_Turno
    {

        private Mapper_Turno mapper = new Mapper_Turno();
        public void CrearTurno(BE_Turno turno) 
        {
            string query = @"INSERT INTO Turnos (Fecha, Horario, Estado, DNI_Cliente, Patente_Vehiculo, DNI_Mecanico)
                            VALUES (@Fecha, @Horario, @Estado, @DNI_Cliente, @Patente_Vehiculo, @DNI_Mecanico)"
                    ;

            SqlParameter[] param = new SqlParameter[] {

                new SqlParameter("@Fecha", turno.Fecha), 
                new SqlParameter("@Horario", turno.Horario.TimeOfDay),
                new SqlParameter("@Estado", turno.Estado),
                new SqlParameter("@DNI_Cliente", turno.Cliente.DNI),
                new SqlParameter("@Patente_Vehiculo", turno.vehiculo.Patente),
                new SqlParameter("@DNI_Mecanico", turno.Mecanico.DNI)
            };

            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(param);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<BE_Turno> obtenerTurnos()
        {
            List<BE_Turno> listaTurnos = new List<BE_Turno>();

            DAL_Cliente clienteDAL = new DAL_Cliente();
            DAL_Usuario mecanicoDAL = new DAL_Usuario();
            DAL_Vehiculo vehiculoDAL = new DAL_Vehiculo();

            string query = "SELECT * FROM Turnos";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.Fill(ds);

            foreach(DataRow fila in ds.Tables[0].Rows)
            {
                string dniCliente = fila["DNI_Cliente"].ToString();
                BE_Cliente ClienteDNI = clienteDAL.obtenerClientePorDni(dniCliente);

                string patenteVehiculo = fila["Patente_Vehiculo"].ToString();
                BE_Vehiculo vehiculoPAtente = vehiculoDAL.obtenerVehiculoPorPatente(patenteVehiculo);

                string dniMecanico = fila["DNI_Mecanico"].ToString();
                Be_Usuario MecanicoDNI = mecanicoDAL.ObtenerPorDNI(dniMecanico);

                listaTurnos.Add(mapper.ToBE(fila, ClienteDNI, vehiculoPAtente, MecanicoDNI));
            }                
            return listaTurnos;
        }

        public BE_Turno ObtenerTurnoPorID(int id)
        {
            DAL_Cliente clienteDAL = new DAL_Cliente();
            DAL_Usuario mecanicoDAL = new DAL_Usuario();
            DAL_Vehiculo vehiculoDAL = new DAL_Vehiculo();

            string query = "SELECT * FROM Turnos WHERE ID_Turno = @ID_Turno"; 
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, ConexionDB.ObtenerConexion());
            da.SelectCommand.Parameters.AddWithValue("@ID_Turno", id);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                string dniCliente = fila["DNI_Cliente"].ToString();
                BE_Cliente ClienteDNI = clienteDAL.obtenerClientePorDni(dniCliente);

                string patenteVehiculo = fila["Patente_Vehiculo"].ToString();
                BE_Vehiculo vehiculoPAtente = vehiculoDAL.obtenerVehiculoPorPatente(patenteVehiculo);

                string dniMecanico = fila["DNI_Mecanico"].ToString();
                Be_Usuario MecanicoDNI = mecanicoDAL.ObtenerPorDNI(dniMecanico);
                return mapper.ToBE(fila, ClienteDNI, vehiculoPAtente, MecanicoDNI);
            }
            return null;
        }

        public void ActualizarDatosTurno(BE_Turno turno)
        {
            string query = @"UPDATE Turnos SET Fecha = @Fecha, Horario = @Horario, Estado = @Estado, DNI_Cliente = @DNI_Cliente, Patente_Vehiculo = @Patente_Vehiculo  , DNI_Mecanico = @DNI_Mecanico WHERE ID_Turno = @ID_Turno";
            DataSet ds = new DataSet();

            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ID_Turno", turno.ID_Turno),
                new SqlParameter("@Fecha", turno.Fecha),
                new SqlParameter("@Horario", turno.Horario.TimeOfDay),
                new SqlParameter("@Estado", turno.Estado),
                new SqlParameter("@DNI_Cliente", turno.Cliente.DNI),
                new SqlParameter("@Patente_Vehiculo", turno.vehiculo.Patente),
                new SqlParameter("@DNI_Mecanico", turno.Mecanico.DNI)
            };

            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(param);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
