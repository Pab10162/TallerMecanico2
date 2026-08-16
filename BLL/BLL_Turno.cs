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
        public delegate void TurnoCreadoHandler(BE_Turno turno, Be_Usuario usuario);

        public event TurnoCreadoHandler turnoCreado;

        public void CrearTurno(BE_Turno turno)
        {
            if (turno.Fecha < DateTime.Today)
            {
                throw new Exception("No puede crearse un turno con una fecha pasada");
            }
            dal.CrearTurno(turno);
            turnoCreado?.Invoke(turno, SessionManager.GetInstance().UsuarioActual);
        }
    }
}
