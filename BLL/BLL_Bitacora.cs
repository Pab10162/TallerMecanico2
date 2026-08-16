using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Clases;
using DAL;
using Servicios;

namespace BLL
{
    public class BLL_Bitacora
    {
        DAL_BitacoraEvento dal = new DAL_BitacoraEvento();
        public void RegistrarEvento(BE_BitacoraEvento evento)
        {
            dal.RegistrarEvento(evento);
        }
        public void ObtenerEventos()
        {
            dal.ObtenerEventos();
        }

    }
}
