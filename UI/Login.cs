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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

    }

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
    }
}
