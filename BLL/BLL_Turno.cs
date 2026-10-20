using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios;
namespace BLL
{
    /// <summary>
    /// RESPONSABILIDAD: Aplicar las reglas de turnos: calcular horarios disponibles de una fecha y registrar el turno.
    /// POR QUÉ EXISTE: El cálculo de disponibilidad es una regla de negocio, no un dato: por eso no está en la DAL ni en la UI.
    /// QUÉ NO HACE: No guarda directamente; delega en DAL_Turno. PENDIENTE: ObtenerClientPorDNI debería vivir solo en BLL_Cliente.
    /// </summary>
    public class BLL_Turno
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        public DAL_Turno dal = new DAL_Turno();

        public event AccionRealizadaHandler accionRealizada;

        #endregion

        #region Operaciones públicas: reglas de negocio que expone a la UI

        public void CrearTurno(BE_Turno turno)
        {
            if (turno.Fecha < DateTime.Today)
            {
                throw new Exception("No puede crearse un turno con una fecha pasada");
            }
            dal.CrearTurno(turno);
            accionRealizada?.Invoke($"Se creó el turno para {turno.Cliente.Nombre}", SessionManager.GetInstance().UsuarioActual);
        }

        public List<BE_Turno> ObtenerTurnos()
        {
            return dal.obtenerTurnos();
        }

        public List<DateTime> ObtenerHorariosDisponibles(DateTime fecha)
        {
            List<TimeSpan> ocupados = dal.ObtenerHorariosOcupados(fecha);
            List<DateTime> disponibles = new List<DateTime>();

            for (int hora = 8; hora <= 21; hora++)
            {
                TimeSpan horaSlot = TimeSpan.FromHours(hora);
                if (!ocupados.Contains(horaSlot))
                {
                    disponibles.Add(fecha.Date + horaSlot);
                }
            }
            return disponibles;
        }

        #endregion
    }
}
