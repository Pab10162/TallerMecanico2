using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace Servicios
{
    public class SessionManager
    {
        private static SessionManager instance;
        public Be_Usuario UsuarioActual {  get; set; }
        private SessionManager(){}

        public static SessionManager GetInstance()
        {
                if (instance == null)
                {
                    instance = new SessionManager();
                }
                return instance;
            
        }

        public void Login(Be_Usuario usuario)
        {
            UsuarioActual = usuario;
        }
        public void Logout()
        {
            UsuarioActual = null;
        }
        public bool haySesionActiva()
        {
            return UsuarioActual != null;
        }
    }
}
