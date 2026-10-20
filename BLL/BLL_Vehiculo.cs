using System;
using System.Collections.Generic;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    /// <summary>
    /// RESPONSABILIDAD: Aplicar las reglas de negocio de vehículos y consultar los vehículos de un cliente por DNI.
    /// POR QUÉ EXISTE: Idem BLL_Cliente: decide, no guarda ni dibuja.
    /// QUÉ NO HACE: Baja todavía no está implementada (pendiente del PN1).
    /// </summary>
    public class BLL_Vehiculo : IABM<BE_Vehiculo>, IDisposable
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private DAL_Vehiculo dal = new DAL_Vehiculo();

        public event AccionRealizadaHandler accionRealizada;

        #endregion

        #region Operaciones públicas: reglas de negocio que expone a la UI

        // --- IABM<BE_Vehiculo> ---
        public void Alta(BE_Vehiculo vehiculo)
        {
            if (dal.obtenerVehiculoPorPatente(vehiculo.Patente) != null)
            {
                throw new Exception("No se puede registrar esa patente. Ya existe.");
            }

            dal.CrearVehiculo(vehiculo);
            accionRealizada?.Invoke($"Se creó vehiculo: {vehiculo.Patente}", SessionManager.GetInstance().UsuarioActual);
        }

        public void Baja(BE_Vehiculo vehiculo)
        {
            // NOTA: Para que esto funcione, debes agregar el método EliminarVehiculo en DAL_Vehiculo
            // (idealmente una baja lógica si el vehículo tiene turnos/trabajos asociados).

            // dal.EliminarVehiculo(vehiculo);
            // accionRealizada?.Invoke($"Se dio de baja al vehiculo: {vehiculo.Patente}", SessionManager.GetInstance().UsuarioActual);

            throw new NotImplementedException("Falta crear el método EliminarVehiculo en DAL_Vehiculo.");
        }

        public void Modificacion(BE_Vehiculo vehiculo)
        {
            dal.ActualizarVehiculo(vehiculo);
            accionRealizada?.Invoke($"Se actualizo dato del vehiculo: {vehiculo.Patente}", SessionManager.GetInstance().UsuarioActual);
        }

        public List<BE_Vehiculo> ObtenerTodos()
        {
            return dal.obtenerVehiculos();
        }

        // --- Métodos propios (no forman parte del CRUD genérico) ---
        public BE_Vehiculo ObtenerPorPatente(string patente)
        {
            return dal.obtenerVehiculoPorPatente(patente);
        }

        public List<BE_Vehiculo> ObtenerPorCliente(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new Exception("DNI vacio");
            }
            return dal.obtenerVehiculosPorCliente(dni);
        }
        #endregion

        #region Liberación de recursos (IDisposable)

        // --- IDisposable: propaga la liberación hacia el DAL ---
        public void Dispose()
        {
            dal?.Dispose();
        }

        #endregion
    }
}