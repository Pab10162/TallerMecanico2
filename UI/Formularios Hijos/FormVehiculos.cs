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
    public partial class FormVehiculos : Form
    {
        public FormVehiculos()
        {
            InitializeComponent();
        }
        string modo = "Ninguno";
        BE_Vehiculo vehiculoSeleccionado;
        BLL_Vehiculo BllVehiculos = new BLL_Vehiculo();
        BE_Cliente clienteSeleccionado;

        public void ActualizarGrilla()
        {
            dgvVehiculo.DataSource = null;
            dgvVehiculo.DataSource = BllVehiculos.obtenerVehiculos();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            modo = "Crear";
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
        private void FormVehiculos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            txtCedula.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtPatente.Enabled = false;
            listBox1.DataSource = new BLL_Cliente().obtenerClientes();
        }

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
                    BllVehiculos.CrearVehiculo(vehiculoNuevo);
                    MessageBox.Show("Vehiculo registrado correctamente");
                    ActualizarGrilla();
                }
                else if(modo == "Modificar")
                {
                    vehiculoSeleccionado.Cedula = txtCedula.Text;
                    vehiculoSeleccionado.Modelo = txtModelo.Text;
                    vehiculoSeleccionado.Patente = txtPatente.Text;
                    vehiculoSeleccionado.Marca = txtMarca.Text;
                    BllVehiculos.ActualizarVehiculo(vehiculoSeleccionado);
                    MessageBox.Show("Vehiculo actualizado correctamente");
                    ActualizarGrilla();
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clienteSeleccionado = listBox1.SelectedItem as BE_Cliente;
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarCliente.Text.ToLower();
            var clientesFiltrados = new BLL_Cliente().obtenerClientes()
                .Where(c => c.DNI.Contains(filtro) ||
                            c.Nombre.ToLower().Contains(filtro) ||
                            c.Apellido.ToLower().Contains(filtro))
                .ToList();
            listBox1.DataSource = clientesFiltrados;
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
    }
}
