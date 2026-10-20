using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace Servicios
{
    /// <summary>
    /// RESPONSABILIDAD: Mantener quién es el usuario con sesión iniciada (Singleton).
    /// POR QUÉ EXISTE: Es información global y única: todas las capas necesitan saber el usuario actual (por ejemplo, para la bitácora).
    /// QUÉ NO HACE: No autentica: eso lo hace BLL_Usuario.Login antes de llamar a Login(usuario).
    /// </summary>
    public class SessionManager
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private static SessionManager instance;

        public Be_Usuario UsuarioActual {  get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        private SessionManager(){}

        #endregion

        #region Operaciones públicas: servicio transversal usado por todas las capas

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

        #endregion
    }
}
