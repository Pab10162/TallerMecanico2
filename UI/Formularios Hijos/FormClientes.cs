using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI.Formularios_Hijos
{
    public partial class FormClientes : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Cliente BLLCLiente;

        string modo = "Ninguno";

        BE_Cliente usuarioSeleccionado;
        string dniInicial;                                    // el DNI que trae Turnos (null si se abre desde el menú)
        public BE_Cliente ClienteRegistrado { get; private set; }   // lo que devuelve al cerrar
        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public FormClientes(BLL_Cliente bllCliente)
        {
            InitializeComponent();
            BLLCLiente = bllCliente;
        }
        public FormClientes(BLL_Cliente bllCliente, string dni) : this(bllCliente)
        {
            dniInicial = dni;
        }
        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void FormClientes_Load(object sender, EventArgs e)
        {
            labelModo.Text = "Modo: -";
            txtDireccion.Enabled = false;
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
            ActualizarGrilla();
            if (dniInicial != null)
            {
                btnCrear_Click(this, EventArgs.Empty);
                txtDNI.Text = dniInicial;
                txtNombre.Focus();
            }
            
        }

        #endregion

        #region Operaciones públicas: lo que otros formularios pueden pedirle a este

        public void ActualizarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = BLLCLiente.ObtenerTodos();
        }
        public void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtApellido.Enabled = true;
        }
        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnCrear_Click(object sender, EventArgs e)
        {
            modo = "Crear";
            labelModo.Text = "Modo: Crear";
            txtDireccion.Enabled = true;
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtDNI.Enabled = true;
            txtTelefono.Enabled = true;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modo == "Crear")
                {
                    string dni = txtDNI.Text;
                    string apellido = txtApellido.Text;
                    string nombre = txtNombre.Text;
                    string telefono = txtTelefono.Text;
                    string direccion = txtDireccion.Text;

                    if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
                    {
                        MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    BE_Cliente clienteNuevo = new BE_Cliente(dni, nombre, apellido, telefono, direccion);
                    BLLCLiente.Alta(clienteNuevo);
                    MessageBox.Show("Cliente registrado correctamente");
                    if (dniInicial != null)
                    {
                        ClienteRegistrado = clienteNuevo;   // el nombre de tu variable local
                        DialogResult = DialogResult.OK;     // cierra la ventana
                        return;
                    }
                    ActualizarGrilla();

                
                }
                else if (modo == "Modificar")
                {
                    if (usuarioSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un usuario para poder modificar");
                        return;
                    }
                    else 
                    {
                        usuarioSeleccionado.Nombre = txtNombre.Text;
                        usuarioSeleccionado.Direccion = txtDireccion.Text;
                        usuarioSeleccionado.Apellido = txtApellido.Text;
                        usuarioSeleccionado.DNI = txtDNI.Text;
                        usuarioSeleccionado.Telefono = txtTelefono.Text;
                        BLLCLiente.Modificacion(usuarioSeleccionado);
                        MessageBox.Show("Se actualizo la informacion correctamente");
                        ActualizarGrilla();
                    }
                }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modo = "Modificar";
            HabilitarCampos();
            labelModo.Text = "Modo: Modificar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = "Ninguno";
            labelModo.Text = "Modo: -";
            txtDireccion.Enabled = false;
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
        }

        #endregion

        #region Eventos de controles: reaccionan a selección, texto o cambios en pantalla

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvClientes.SelectedRows.Count > 0)
            {
                if (modo == "Crear") return;
                usuarioSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as BE_Cliente;
                txtApellido.Text = usuarioSeleccionado.Apellido;
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtDNI.Text = usuarioSeleccionado.DNI;
                txtTelefono.Text = usuarioSeleccionado.Telefono;
                txtDireccion.Text = usuarioSeleccionado.Direccion;
            }
            
        }

        #endregion
    }
}
