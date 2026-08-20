using BE;
using BE.Clases;
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
using UI.Formularios_Hijos;

namespace UI
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        BLL_Usuario usuariobll = new BLL_Usuario();
        BLL_Cliente clientebll = new BLL_Cliente();
        BLL_Vehiculo vehiculobll = new BLL_Vehiculo();
        BLL_Turno turnobll = new BLL_Turno();
        BLL_Bitacora bitacorabll = new BLL_Bitacora();

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Be_Usuario usuario = SessionManager.GetInstance().UsuarioActual;

            administracionToolStripMenuItem.Visible = usuario is Be_Administrador;
            clientesToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Recepcionista;
            diagnosticoToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Mecanico || usuario is Be_JefeTaller;
            cobrosToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Cajero;
            usuariobll.accionRealizada += RegistrarEnBitacora;
            clientebll.accionRealizada += RegistrarEnBitacora;
            vehiculobll.accionRealizada += RegistrarEnBitacora;
            turnobll.accionRealizada += RegistrarEnBitacora;
        }
        private void RegistrarEnBitacora(string descripcion, Be_Usuario usuario)
        {
            BE_BitacoraEvento evento = new BE_BitacoraEvento(DateTime.Now, DateTime.Now, usuario, descripcion);
            bitacorabll.RegistrarEvento(evento);
        }
        public void CargarMenu()
        {
            Be_Usuario usuario = SessionManager.GetInstance().UsuarioActual;
            administracionToolStripMenuItem.Visible = usuario is Be_Administrador;
            clientesToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Recepcionista;
            diagnosticoToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Mecanico || usuario is Be_JefeTaller;
            cobrosToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Cajero;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ABMUsuario frmABM = new Form_ABMUsuario();
            frmABM.MdiParent = this;
            frmABM.WindowState = FormWindowState.Maximized;
            frmABM.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.MdiParent = this;
            frmLogin.Show();
        }

        private void unloginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BLL_Usuario().Logout();
            CargarMenu(); // recarga el menú, ahora sin usuario activo
                          // cerrar todos los formularios hijos abiertos
            foreach (Form hijo in this.MdiChildren)
            {
                hijo.Close();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.WindowState = FormWindowState.Maximized;
            formClientes.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVehiculos frmVehiculos = new FormVehiculos();
            frmVehiculos.MdiParent = this;
            frmVehiculos.WindowState = FormWindowState.Maximized;
            frmVehiculos.Show();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Turnos frmTurnos = new Form_Turnos();
            frmTurnos.MdiParent = this;
            frmTurnos.WindowState = FormWindowState.Maximized;
            frmTurnos.Show();
        }
    }
}
