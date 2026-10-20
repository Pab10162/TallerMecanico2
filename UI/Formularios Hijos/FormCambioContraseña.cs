using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios_Hijos
{
    /// <summary>
    /// RESPONSABILIDAD: Pedir la contraseña actual y la nueva, y delegar el cambio en la BLL.
    /// POR QUÉ EXISTE: Un usuario debe poder cambiar su propia clave sin pasar por el administrador.
    /// QUÉ NO HACE: No verifica la contraseña actual: lo hace BLL_Usuario.CambiarPassword.
    /// </summary>
    public partial class FormCambioContraseña : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Usuario bllUsuario;

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public FormCambioContraseña(BLL_Usuario bllUsuarioCompartido)
        {
            InitializeComponent();
            bllUsuario = bllUsuarioCompartido;
        }

        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevaPassword.Text != txtConfirmacionPassword.Text)
                {
                    MessageBox.Show("La nueva contraseña y su confirmación no coinciden");
                    return;
                }

                bllUsuario.CambiarPassword(txtPasswordActual.Text, txtNuevaPassword.Text);
                MessageBox.Show("Contraseña actualizada correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerActual_Click(object sender, EventArgs e)
        {
            ToggleVerContraseña(txtPasswordActual, btnVerActual);
        }

        private void btnVerNueva_Click(object sender, EventArgs e)
        {
            ToggleVerContraseña(txtNuevaPassword, btnVerNueva);
        }

        private void btnVerConfirmar_Click(object sender, EventArgs e)
        {
            ToggleVerContraseña(txtConfirmacionPassword, btnVerConfirmar);
        }

        #endregion

        #region Métodos auxiliares: apoyo interno que no forma parte de la interfaz pública

        private void ToggleVerContraseña(TextBox txt, Button btn)
        {
            if (txt.PasswordChar == '\0')
            {
                txt.PasswordChar = '*';
                btn.Text = "👁";
            }
            else
            {
                txt.PasswordChar = '\0';
                btn.Text = "🙈";
            }
        }

        #endregion
    }
}
