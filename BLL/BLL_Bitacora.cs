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
    /// <summary>
    /// RESPONSABILIDAD: Registrar y consultar eventos de la bitácora.
    /// POR QUÉ EXISTE: Es el destino del Observer: Inicio escucha las acciones de las demás BLL y las manda acá.
    /// QUÉ NO HACE: No decide qué se audita.
    /// </summary>
    public class BLL_Bitacora
    {
        DAL_BitacoraEvento dal = new DAL_BitacoraEvento();
        public void RegistrarEvento(BE_BitacoraEvento evento)
        {
            dal.RegistrarEvento(evento);
        }
        public List<BE_BitacoraEvento> ObtenerEventos()
        {
            return dal.ObtenerEventos();
        }

    }
}
