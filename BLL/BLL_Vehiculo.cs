using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Vehiculo
    {
        DAL_Vehiculo dal = new DAL_Vehiculo();
        public void CrearVehiculo(BE_Vehiculo vehiculo)
        {
            if (dal.obtenerVehiculoPorPatente(vehiculo.Patente) != null)
            {
                throw new Exception("No se puede registrar esa patente");
            }
            dal.CrearVehiculo(vehiculo);
        }
        public List<BE_Vehiculo> obtenerVehiculos()
        {
            return dal.obtenerVehiculos();
        }

        public void ActualizarVehiculo(BE_Vehiculo vehiculo)
        {
            dal.ActualizarVehiculo(vehiculo);
        }
    }
}
