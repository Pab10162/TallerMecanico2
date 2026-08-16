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
    public class ConexionDB
    {
        private static string conexion = @"Data Source=.;Initial Catalog=AutoFixDB;Integrated Security=True";
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexion);
        }
    }
}
