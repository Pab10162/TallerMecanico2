using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    /// <summary>
    /// RESPONSABILIDAD: Pedir credenciales y delegar la autenticación en BLL_Usuario.
    /// POR QUÉ EXISTE: Es la puerta de entrada al sistema.
    /// QUÉ NO HACE: No valida contraseñas ni cuenta intentos: solo captura y muestra errores.
    /// </summary>
    public partial class Login : Form
    {
        #region Constructores: cómo se crea y qué dependencias recibe

        public Login()
        {
            InitializeComponent();
        }

        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void Login_Load(object sender, EventArgs e)
        {
            Traductor.GetInstance().CargarIdioma("es");
            AplicarTraduccion();
        }

        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            BLL_Usuario usuarioBLL = new BLL_Usuario();
            var instance = SessionManager.GetInstance();
            if (instance.haySesionActiva())
            {
                MessageBox.Show("Ya hay sesion activa, cierre sesion primero");
                return;
            }

            string nombreUsuario = txtUserName.Text;
            string contraseña = txtPassword.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Complete todos los campos"); return;
            }
            try
            {
                usuarioBLL.Login(nombreUsuario, contraseña);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            if (this.MdiParent is Inicio inicio)
            {
                inicio.CargarMenu();
            }
            this.Close();
        }

        #endregion

        #region Métodos auxiliares: apoyo interno que no forma parte de la interfaz pública

        private void AplicarTraduccion()
        {
            var t = Traductor.GetInstance();
            label1.Text = t.Traducir("loginLabel1");
            label2.Text = t.Traducir("loginLabel2");
            label3.Text = t.Traducir("loginLabel3");
            btnLogin.Text = t.Traducir("loginBtnLogin");
        }

        #endregion
    }
}
