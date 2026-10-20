// DAL/DAL_BackupRestore.cs
using System;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// RESPONSABILIDAD: Ejecutar el backup y el restore de la base AutoFixDB en SQL Server.
    /// POR QUÉ EXISTE: Son operaciones a nivel servidor (BACKUP / RESTORE DATABASE), distintas del CRUD de entidades, por eso tienen su propia DAL.
    /// QUÉ NO HACE: No elige rutas ni confirma con el usuario: eso es de la UI.
    /// </summary>
    public class DAL_BackupRestore
    {
        public void RealizarBackup(string rutaArchivo)
        {
            string query = $"BACKUP DATABASE AutoFixDB TO DISK = @Ruta"; //Consulta para realizar el backup de la base de datos
            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ruta", rutaArchivo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RealizarRestore(string rutaArchivo)
        {
            string query = $@"
                ALTER DATABASE AutoFixDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE AutoFixDB FROM DISK = @Ruta WITH REPLACE;  
                ALTER DATABASE AutoFixDB SET MULTI_USER;";
            using (SqlConnection conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ruta", rutaArchivo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}