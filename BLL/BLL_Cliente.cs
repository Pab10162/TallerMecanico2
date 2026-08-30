using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BLL_Cliente : IABM<BE_Cliente>, IDisposable
    {
        private DAL_Cliente dal = new DAL_Cliente();
        public event AccionRealizadaHandler accionRealizada;

        // --- IABM<BE_Cliente> ---
        public void Alta(BE_Cliente cliente)
        {
            if (dal.obtenerClientePorDni(cliente.DNI) != null)
            {
                throw new Exception("Ese DNI ya se encuentra registrado");
            }

            dal.CrearCliente(cliente);
            accionRealizada?.Invoke($"Se creó el cliente: {cliente.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Baja(BE_Cliente cliente)
        {
            dal.EliminarCliente(cliente);
            accionRealizada?.Invoke($"Se dio de baja al cliente: {cliente.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Modificacion(BE_Cliente cliente)
        {
            dal.ActualizarCliente(cliente);
            accionRealizada?.Invoke($"Se actualizó dato del cliente: {cliente.DNI}", SessionManager.GetInstance().UsuarioActual);
        }

        public List<BE_Cliente> ObtenerTodos()
        {
            return dal.ObtenerClientes();
        }

        // --- IDisposable: propaga la liberación hacia el DAL ---
        public void Dispose()
        {
            dal?.Dispose();
        }
    }
}