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

namespace UI.Formularios_Hijos
{
    public partial class Form_Turnos : Form
    {
        public Form_Turnos()
        {
            InitializeComponent();
        }
        string modo = "Ninguno";
        BE_Turno turnoSeleccionado;
        BE_Cliente clienteSeleccionado;
        BE_Vehiculo vehiculoSeleccionado;
        Be_Usuario usuarioSeleccionado;
        BLL_Turno bllTurno = new BLL_Turno();

        public void ActualizarGrilla()
        {
            dgvTurnos.DataSource = null;
            dgvTurnos.DataSource = bllTurno.ObtenerTurnos();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            modo = "Crear";
            labelModo.Text = "Modo: Crear";
            dtpFecha.Enabled = true;
            dtpHorario.Enabled = true;
        }


        private void dgvTurnos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTurnos.SelectedRows.Count > 0)
            {
                turnoSeleccionado = dgvTurnos.SelectedRows[0].DataBoundItem as BE_Turno;
                cmbEstado.Text = turnoSeleccionado.Estado.ToString();
            }
        }

        private void Form_Turnos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            dtpFecha.Enabled = false;
            dtpHorario.Enabled = false;
            cmbEstado.Enabled = false;
            listBox1.DataSource = new BLL_Vehiculo().obtenerVehiculos();
            listBox2.DataSource = new BLL_Cliente().obtenerClientes();
            listBox3.DataSource = new BLL_Usuario().obtenerUsuarios().Where(u => u is Be_Mecanico);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionado != null)
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
                    else if (vehiculoSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un vehiculo");
                        return;
                    }
                    else if (usuarioSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un mecanico");
                        return;
                    }
                    BE_Turno turnoNuevo = new BE_Turno(dtpFecha.Value, dtpHorario.Value, "Pendiente", clienteSeleccionado, vehiculoSeleccionado, usuarioSeleccionado);
                    bllTurno.CrearTurno(turnoNuevo);
                    MessageBox.Show("Turno registrado correctamente");
                    ActualizarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculoSeleccionado = listBox1.SelectedItem as BE_Vehiculo;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clienteSeleccionado = listBox2.SelectedItem as BE_Cliente;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioSeleccionado = listBox3.SelectedItem as Be_Usuario;
        }
    }
}
