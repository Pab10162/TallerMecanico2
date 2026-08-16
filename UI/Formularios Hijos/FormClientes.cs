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
        public FormClientes()
        {
            InitializeComponent();
        }
        string modo = "Ninguno";
        BLL_Cliente BLLCLiente = new BLL_Cliente();
        BE_Cliente usuarioSeleccionado;

        public void ActualizarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = BLLCLiente.obtenerClientes();
        }

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
                    BLLCLiente.CrearCliente(clienteNuevo);
                    MessageBox.Show("Cliente registrado correctamente");
                    ActualizarGrilla();

                
                }
                else if (modo == "Modificar")
                {
                    usuarioSeleccionado.Nombre = txtNombre.Text;
                    usuarioSeleccionado.Direccion = txtDireccion.Text;
                    usuarioSeleccionado.Apellido = txtApellido.Text;
                    usuarioSeleccionado.DNI = txtDNI.Text;
                    usuarioSeleccionado.Telefono = txtTelefono.Text;
                    BLLCLiente.ActualizarCliente(usuarioSeleccionado);
                    MessageBox.Show("Se actualizo la informacion correctamente");
                    ActualizarGrilla();
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
            labelModo.Text = "Modo: Modificar";
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvClientes.SelectedRows.Count > 0)
            {
                usuarioSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as BE_Cliente;
                txtApellido.Text = usuarioSeleccionado.Apellido;
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtDNI.Text = usuarioSeleccionado.DNI;
                txtTelefono.Text = usuarioSeleccionado.Telefono;
                txtDireccion.Text = usuarioSeleccionado.Direccion;
            }
            
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            labelModo.Text = "Modo: -";
            txtDireccion.Enabled = false;
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;
            ActualizarGrilla();
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
    }
}
