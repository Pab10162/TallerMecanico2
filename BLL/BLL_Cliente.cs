using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Cliente
    {

        DAL_Cliente dal = new DAL_Cliente();
        public void CrearCliente(BE_Cliente cliente)
        {
            if(dal.obtenerClientePorDni(cliente.DNI) != null)
            {
                throw new Exception("Ese DNI ya se encuentra registrado");
            }
            dal.CrearCliente(cliente);
        }

        public  List<BE_Cliente> obtenerClientes()
        {
            return dal.ObtenerClientes();
        }

        public void ActualizarCliente(BE_Cliente cliente)
        {
            dal.ActualizarCliente(cliente);
        }
    }
}
