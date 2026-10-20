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
    /// <summary>
    /// RESPONSABILIDAD: Asignar un turno: buscar el cliente por DNI, elegir su vehículo, fecha y horario libre.
    /// POR QUÉ EXISTE: Es la pantalla del RFN1; guía el flujo cliente -> vehículo -> horario.
    /// QUÉ NO HACE: No calcula horarios libres (BLL_Turno) ni guarda (DAL_Turno). La búsqueda de clientes la resuelve BLL_Cliente. Modificar turno todavía no está implementado.
    /// </summary>
    public partial class Form_Turnos : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Turno bllTurno;

        string modo = "Ninguno";

        BE_Turno turnoSeleccionado;

        List<DateTime> horariosDisponibles = new List<DateTime>();

        BE_Cliente clienteEncontrado;

        BE_Vehiculo vehiculoSeleccionado;

        // PENDIENTE: esta BLL propia no está conectada a la bitácora de Inicio; conviene recibirla por constructor como bllTurno.
        BLL_Cliente BLL_Cliente;
        BLL_Vehiculo bllVehiculo;

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public Form_Turnos(BLL_Turno bllTurnoCompartido, BLL_Cliente bLLCliente, BLL_Vehiculo BllVehiculo)
        {
            InitializeComponent();
            bllTurno = bllTurnoCompartido;
            BLL_Cliente = bLLCliente;
            bllVehiculo = BllVehiculo;
        }

        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void Form_Turnos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            dtpFecha.Enabled = false;
            cmbHorario.Enabled = false;
            cmbEstado.Enabled = false;
            btnRegistrarCliente.Visible = false;


            listBox1.DataSource = null; // vehículos, arranca vacío

            cmbHorario.FormattingEnabled = true;
            cmbHorario.Format += (s, e2) =>
            {
                if (e2.ListItem is DateTime dt)
                    e2.Value = dt.ToString("HH:mm");
            };
        }

        #endregion

        #region Operaciones públicas: lo que otros formularios pueden pedirle a este

        public void ActualizarGrilla()
        {
            dgvTurnos.DataSource = null;
            dgvTurnos.DataSource = bllTurno.ObtenerTurnos();
            if (dgvTurnos.Columns["Horario"] != null)
            {
                dgvTurnos.Columns["Horario"].DefaultCellStyle.Format = "HH:mm";
            }
        }
        private void MostrarCliente(BE_Cliente cliente)
        {
            clienteEncontrado = cliente;
            lblClienteBuscado.Text = cliente.Nombre + " " + cliente.Apellido + " - DNI " + cliente.DNI;
            btnRegistrarCliente.Visible = false;
            CargarVehiculo();
        }
        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            modo = "Crear";
            labelModo.Text = "Modo: Crear";
            dtpFecha.Enabled = true;
            cmbHorario.Enabled = true;
            dtpFecha_ValueChanged(sender, e);
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
                    if (vehiculoSeleccionado == null)
                    {
                        MessageBox.Show("Debe seleccionar un vehiculo");
                        return;
                    }
                    if (cmbHorario.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un horario");
                        return;
                    }
                    DateTime horarioSeleccionado = horariosDisponibles[cmbHorario.SelectedIndex];
                    BE_Turno turnoNuevo = new BE_Turno(dtpFecha.Value, horarioSeleccionado, "Pendiente", vehiculoSeleccionado.Cliente, vehiculoSeleccionado);
                    bllTurno.CrearTurno(turnoNuevo);
                    MessageBox.Show("Turno registrado correctamente");
                    ActualizarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + " " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = "Ninguno";
            labelModo.Text = modo;
            dtpFecha.Enabled = false;
            cmbHorario.Enabled = false;
            listBox1.DataSource = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtDNIBuscado.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("DNI no puede estar vacio");
                return;
            }

            BE_Cliente cliente = BLL_Cliente.ObtenerClientePorDNI(dni);

            if (cliente != null)
            {
                MostrarCliente(cliente);
                return;
            }

            clienteEncontrado = null;
            lblClienteBuscado.Text = "Cliente no encontrado";
            DialogResult respuesta = MessageBox.Show("¿Desea registrar al cliente?", "Confirmación",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            btnRegistrarCliente.Visible = (respuesta == DialogResult.Yes);
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            using (FormClientes frm = new FormClientes(BLL_Cliente, txtDNIBuscado.Text.Trim()))
            {
                if (frm.ShowDialog(this) == DialogResult.OK && frm.ClienteRegistrado != null)
                {
                    MostrarCliente(frm.ClienteRegistrado);
                }
            }
        }

        private void CargarVehiculo()
        {
            List<BE_Vehiculo> ListaVehiculos = bllVehiculo.ObtenerPorCliente(clienteEncontrado.DNI);
            listBox1.DataSource = null;
            if (ListaVehiculos.Count > 0)
            {
                listBox1.DisplayMember = "Patente";
                listBox1.DataSource = ListaVehiculos;
                lblVehiculo.Text = string.Empty;
            }
            else
            {
                vehiculoSeleccionado = null;
                lblVehiculo.Text = "El cliente no tiene vehiculos registrados";
            }
        }

        #endregion

        #region Eventos de controles: reaccionan a selección, texto o cambios en pantalla

        private void dgvTurnos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTurnos.SelectedRows.Count > 0)
            {
                turnoSeleccionado = dgvTurnos.SelectedRows[0].DataBoundItem as BE_Turno;
                cmbEstado.Text = turnoSeleccionado.Estado.ToString();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehiculoSeleccionado = listBox1.SelectedItem as BE_Vehiculo;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            horariosDisponibles = bllTurno.ObtenerHorariosDisponibles(dtpFecha.Value);
            cmbHorario.DataSource = null;
            cmbHorario.DataSource = horariosDisponibles.Select(h => h.ToString("HH:mm")).ToList();
            cmbHorario.Enabled = true;
        
        }
        private void txtDNIBuscado_TextChanged(object sender, EventArgs e)
        {
            clienteEncontrado = null;
            lblClienteBuscado.Text = string.Empty;
            btnRegistrarCliente.Visible = false;
            listBox1.DataSource = null;
        }
        #endregion


    }
}
