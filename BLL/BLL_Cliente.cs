using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Cliente
    {
        public event AccionRealizadaHandler accionRealizada;
        DAL_Cliente dal = new DAL_Cliente();
        public void CrearCliente(BE_Cliente cliente)
        {
            if(dal.obtenerClientePorDni(cliente.DNI) != null)
            {
                throw new Exception("Ese DNI ya se encuentra registrado");
            }
            dal.CrearCliente(cliente);
            accionRealizada?.Invoke($"Se creo cliente: {cliente.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public  List<BE_Cliente> obtenerClientes()
        {
            return dal.ObtenerClientes();
        }

        public void ActualizarCliente(BE_Cliente cliente)
        {
            dal.ActualizarCliente(cliente);
            accionRealizada?.Invoke($"Se actualizo dato del cliente: {cliente.DNI}", SessionManager.GetInstance().UsuarioActual);
        }
    }
}
