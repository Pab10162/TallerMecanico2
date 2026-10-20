using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI.Formularios_Hijos
{
    /// <summary>
    /// RESPONSABILIDAD: Alta, modificación y consulta de vehículos; asocia cada vehículo a su cliente propietario.
    /// POR QUÉ EXISTE: Mismo criterio que FormClientes: una sola pantalla de alta que más adelante Turnos podrá reutilizar.
    /// QUÉ NO HACE: Delega en BLL_Vehiculo; no contiene reglas de negocio ni SQL.
    /// </summary>
    public partial class FormVehiculos : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Vehiculo BllVehiculos;

        string modo = "Ninguno";

        BE_Vehiculo vehiculoSeleccionado;

        BE_Cliente clienteSeleccionado;
        BE_Cliente clienteFijo;                                   // el cliente que trae Turnos (null si se abre desde el menú)
        public BE_Vehiculo VehiculoRegistrado { get; private set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public FormVehiculos(BLL_Vehiculo bllVehiculo)
        {
            InitializeComponent();
            BllVehiculos = bllVehiculo;
        }

        public FormVehiculos(BLL_Vehiculo bllVehiculo, BE_Cliente cliente) : this(bllVehiculo)
        {
            clienteFijo = cliente;
        }
        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void FormVehiculos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            txtCedula.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtPatente.Enabled = false;
            if (clienteFijo == null)
            {
                listBox1.DataSource = new BLL_Cliente().ObtenerTodos();
            }
            else
            {
                btnCrear_Click(this, EventArgs.Empty);
                clienteSeleccionado = clienteFijo;
                listBox1.Enabled = false;
                txtBuscarCliente.Enabled = false;
                txtPatente.Focus();
            }
        }

        #endregion

        #region Operaciones públicas: lo que otros formularios pueden pedirle a este

        public void ActualizarGrilla()
        {
            dgvVehiculo.DataSource = null;
            dgvVehiculo.DataSource = BllVehiculos.ObtenerTodos();
        }

        public void LimpiarCampos()
        {
            txtPatente.Text = null;
            txtModelo.Text = null;
            txtMarca.Text = null;
            txtCedula.Text = null;
        }

        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnCrear_Click(object sender, EventArgs e)
        {
            modo = "Crear";
            LimpiarCampos();
            labelModo.Text = "Modo: Crear";
            txtCedula.Enabled = true;
            txtMarca.Enabled = true;
            txtModelo.Enabled = true;
            txtPatente.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (vehiculoSeleccionado != null)
            {
                modo = "Modificar";
                labelModo.Text = "Modo: Modificar";
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modo == "Crear")
                {
                    if (clienteSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un cliente");
                        return;
                    }
                    BE_Vehiculo vehiculoNuevo = new BE_Vehiculo(txtMarca.Text, txtModelo.Text, txtPatente.Text, txtCedula.Text, clienteSeleccionado);
                    BllVehiculos.Alta(vehiculoNuevo);
                    if (clienteFijo != null)
                    {
                        VehiculoRegistrado = vehiculoNuevo;
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    MessageBox.Show("Vehiculo registrado correctamente");
                    ActualizarGrilla();
                    LimpiarCampos();
                }
                else if(modo == "Modificar")
                {
                    vehiculoSeleccionado.Cedula = txtCedula.Text;
                    vehiculoSeleccionado.Modelo = txtModelo.Text;
                    vehiculoSeleccionado.Patente = txtPatente.Text;
                    vehiculoSeleccionado.Marca = txtMarca.Text;
                    BllVehiculos.Modificacion(vehiculoSeleccionado);
                    MessageBox.Show("Vehiculo actualizado correctamente");
                    ActualizarGrilla();
                    LimpiarCampos();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = "Ninguno";
            labelModo.Text = "Modo: -";
            txtCedula.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtPatente.Enabled = false;
        }

        #endregion

        #region Eventos de controles: reaccionan a selección, texto o cambios en pantalla

        private void dgvVehiculo_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvVehiculo.SelectedRows.Count > 0)
            {
                vehiculoSeleccionado = dgvVehiculo.SelectedRows[0].DataBoundItem as BE_Vehiculo;
                txtPatente.Text = vehiculoSeleccionado.Patente;
                txtModelo.Text = vehiculoSeleccionado.Modelo;
                txtMarca.Text = vehiculoSeleccionado.Marca;
                txtCedula.Text = vehiculoSeleccionado.Cedula;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clienteSeleccionado = listBox1.SelectedItem as BE_Cliente;
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarCliente.Text.ToLower();
            var clientesFiltrados = new BLL_Cliente().ObtenerTodos()
                .Where(c => c.DNI.Contains(filtro) ||
                            c.Nombre.ToLower().Contains(filtro) ||
                            c.Apellido.ToLower().Contains(filtro))
                .ToList();
            listBox1.DataSource = clientesFiltrados;
        }

        #endregion
    }
}
