using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    /// <summary>
    /// RESPONSABILIDAD: Entregar la cadena de conexión a SQL Server (AutoFixDB).
    /// POR QUÉ EXISTE: Si cambia el servidor o la base, se modifica un solo lugar y no cada DAL.
    /// QUÉ NO HACE: No abre ni cierra conexiones: cada DAL maneja su propio ciclo de vida.
    /// </summary>
    public class ConexionDB
    {
        private static string conexion = @"Data Source=.;Initial Catalog=AutoFixDB;Integrated Security=True";
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexion);
        }
    }
}
