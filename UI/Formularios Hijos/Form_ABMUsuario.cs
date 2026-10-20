using BE;
using BE.SubClases;
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

namespace UI
{
    /// <summary>
    /// RESPONSABILIDAD: Permitir alta, modificación, baja lógica y desbloqueo de usuarios.
    /// POR QUÉ EXISTE: Es la pantalla de administración de cuentas.
    /// QUÉ NO HACE: No aplica las reglas de usuarios: las pide a BLL_Usuario.
    /// </summary>
    public partial class Form_ABMUsuario : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Usuario BLL_Usuario;

        Be_Usuario usuarioSeleccionado;

        string modo = "Ninguno";

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public Form_ABMUsuario(BLL_Usuario bllUsuario)
        {
            InitializeComponent();
            BLL_Usuario = bllUsuario;
        }

        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void Form_ABMUsuario_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            panelCampos.Enabled = false;
            labelModo.Text = "Modo: -";
        }

        #endregion

        #region Operaciones públicas: lo que otros formularios pueden pedirle a este

        public void ActualizarGrilla()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = BLL_Usuario.ObtenerTodos();
            dgvUsuarios.Columns["Contraseña"].Visible = false;
            dgvUsuarios.Columns["idioma"].Visible = false;
        }

        public void LimpiarCampos()
        {
            txtApellido.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
            txtEmail.Text = null;
            cmbRol.Text = null;
            ckbActivo.Checked = false;
            ckbBloqueado.Checked = false;
        }

        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnCrear_Click(object sender, EventArgs e)
        {
            modo = "Crear";
            labelModo.Text = "Modo: Crear"; 
            panelCampos.Enabled = true;
            LimpiarCampos();
            txtDNI.Enabled = true;
            txtEmail.Enabled = true;
        }

        //No debe poderse modificar el mail o dni del usuario
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario para realizar esta funcion");
                return;
            }
            modo = "Modificar";
            labelModo.Text = "Modo: Modificar";
            panelCampos.Enabled = true;
            txtDNI.Enabled = false;
            txtEmail.Enabled = false;
        }

        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario para realizar esta funcion");
                    return;
                }
                if (usuarioSeleccionado.Activo == true)
                {
                    usuarioSeleccionado.Activo = false;
                }
                else
                {
                    usuarioSeleccionado.Activo = true;
                }
                BLL_Usuario.Modificacion(usuarioSeleccionado);
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void btnDesbloquear_Click(object sender, EventArgs e)
            {
                try
                {
                    if (usuarioSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un usuario para realizar esta funcion");
                        return;
                    }
                    usuarioSeleccionado.Bloqueado = false;
         
                    BLL_Usuario.Modificacion(usuarioSeleccionado);
                    ActualizarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (modo == "Crear")
            {
                try
                {
                    string dni = txtDNI.Text;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string mail = txtEmail.Text;

                    if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(mail))
                    {
                        MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cmbRol.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar un rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ckbActivo.Checked == ckbBloqueado.Checked)
                    {
                        MessageBox.Show("Los botones de activo y bloqueado no pueden ser iguales"); return;
                    }

                    if (new BLL_Usuario().ObtenerTodos().Any(i => i.DNI == dni))
                    {
                        MessageBox.Show("No se puede ingresar usuario con ese DNI");
                        return;
                    }
                    // Crear nombre de usuario, es la combinacion de los primeros dos digitos de nombre + apellido + dni ultimos 2 digitos
                    string nombreUsuario = (txtNombre.Text.Substring(0, 2) +
                                            txtApellido.Text.Substring(0, 2) +
                                            txtDNI.Text.Substring(txtDNI.Text.Length - 2)).ToLower();

                    //Creamos la contraseña combinando apellido y nombre
                    string contraseñaCombinada = (txtApellido.Text + txtNombre.Text).ToLower();
                    string contraseñaEncriptadad = CryptoManager.Encriptar(contraseñaCombinada);
                    //Creamos el usuario
                    string rol = cmbRol.SelectedItem.ToString();
                    Be_Usuario usuario;
                    switch (rol)
                    {
                        case "Administrador":
                            usuario = new Be_Administrador(txtApellido.Text, contraseñaEncriptadad, txtDNI.Text, txtEmail.Text, txtNombre.Text, nombreUsuario, "ES", ckbBloqueado.Checked, ckbActivo.Checked, rol);
                            break;
                        case "Mecanico":
                            usuario = new Be_Mecanico(txtApellido.Text, contraseñaEncriptadad, txtDNI.Text, txtEmail.Text, txtNombre.Text, nombreUsuario, "ES", ckbBloqueado.Checked, ckbActivo.Checked, rol);
                            break;
                        case "Cajero":
                            usuario = new Be_Cajero(txtApellido.Text, contraseñaEncriptadad, txtDNI.Text, txtEmail.Text, txtNombre.Text, nombreUsuario, "ES", ckbBloqueado.Checked, ckbActivo.Checked, rol);
                            break;
                        case "Jefe de Taller":
                            usuario = new Be_JefeTaller(txtApellido.Text, contraseñaEncriptadad, txtDNI.Text, txtEmail.Text, txtNombre.Text, nombreUsuario, "ES", ckbBloqueado.Checked, ckbActivo.Checked, rol);
                            break;
                        case "Recepcionista":
                            usuario = new Be_Recepcionista(txtApellido.Text, contraseñaEncriptadad, txtDNI.Text, txtEmail.Text, txtNombre.Text, nombreUsuario, "ES", ckbBloqueado.Checked, ckbActivo.Checked, rol);
                            break;
                        default:
                            throw new Exception("Rol no reconocido");
                    }

                    BLL_Usuario.Alta(usuario);
                    MessageBox.Show("Usuario creado correctamente");
                    ActualizarGrilla();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (modo == "Modificar")
            {
                try
                {
                    if (usuarioSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un usuario para realizar esta funcion");
                        return;
                    }
                    usuarioSeleccionado.Nombre = txtNombre.Text;
                    usuarioSeleccionado.Apellido = txtApellido.Text;
                    usuarioSeleccionado.Rol = cmbRol.SelectedItem.ToString();
                    BLL_Usuario.Modificacion(usuarioSeleccionado);
                    MessageBox.Show("Usuario modificado correctamente");
                    ActualizarGrilla();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = "Ninguno";
            labelModo.Text = "Modo: -";
            panelCampos.Enabled = false;
            LimpiarCampos();
            txtDNI.Enabled = false;
            txtEmail.Enabled = false;
            usuarioSeleccionado = null;
        }

        #endregion

        #region Eventos de controles: reaccionan a selección, texto o cambios en pantalla

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Be_Usuario;
                txtApellido.Text = usuarioSeleccionado.Apellido.ToString();
                txtNombre.Text = usuarioSeleccionado.Nombre.ToString();
                txtEmail.Text = usuarioSeleccionado.Email.ToString();
                txtDNI.Text = usuarioSeleccionado.DNI.ToString();
                txtEmail.Enabled = false;
                txtDNI.Enabled = false;
                cmbRol.Text = usuarioSeleccionado.Rol.ToString();
                ckbActivo.Checked = usuarioSeleccionado.Activo;
                ckbBloqueado.Checked = usuarioSeleccionado.Bloqueado;
            }
        }

        #endregion
    }

}
