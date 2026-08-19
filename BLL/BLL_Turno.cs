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
    public class BLL_Turno
    {
        public DAL_Turno dal = new DAL_Turno();
        public event AccionRealizadaHandler accionRealizada;

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
    }
}
