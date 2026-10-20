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
using UI.BackUpRestore;
using UI.Formularios_Hijos;

namespace UI
{
    /// <summary>
    /// RESPONSABILIDAD: Ser el contenedor MDI: mostrar el menú según el rol, abrir los formularios hijos y conectar la bitácora.
    /// POR QUÉ EXISTE: Es el único lugar que crea las BLL compartidas y se suscribe a sus eventos; así todos los formularios hijos auditan igual.
    /// QUÉ NO HACE: No contiene reglas de negocio ni SQL.
    /// </summary>
    public partial class Inicio : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Usuario usuariobll = new BLL_Usuario();

        BLL_Cliente clientebll = new BLL_Cliente();

        BLL_Vehiculo vehiculobll = new BLL_Vehiculo();

        BLL_Turno turnobll = new BLL_Turno();

        BLL_Bitacora bitacorabll = new BLL_Bitacora();

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public Inicio()
        {
            InitializeComponent();
        }

        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void Inicio_Load(object sender, EventArgs e)
        {
            Be_Usuario usuario = SessionManager.GetInstance().UsuarioActual;
            CargarMenu();

            administracionToolStripMenuItem.Visible = usuario is Be_Administrador;
            clientesToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Recepcionista;
            diagnosticoToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Mecanico || usuario is Be_JefeTaller;
            cobrosToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Cajero || usuario is Be_Recepcionista;
            // Patrón Observer: cada BLL avisa "pasó algo" y Inicio lo convierte en un registro de bitácora.
            // Por eso los formularios hijos reciben ESTAS instancias y no crean sus propias BLL (una BLL nueva no tendría suscriptor).
            usuariobll.accionRealizada += RegistrarEnBitacora;
            clientebll.accionRealizada += RegistrarEnBitacora;
            vehiculobll.accionRealizada += RegistrarEnBitacora;
            turnobll.accionRealizada += RegistrarEnBitacora;
        }

        #endregion

        #region Operaciones públicas: lo que otros formularios pueden pedirle a este

        public void CargarMenu()
        {
            Be_Usuario usuario = SessionManager.GetInstance().UsuarioActual;

            if (usuario == null)
                Traductor.GetInstance().CargarIdioma("es");
            else
                Traductor.GetInstance().CargarIdioma(usuario.idioma);

            if (usuario == null)
            {
                unloginToolStripMenuItem.Enabled = false;
                backupToolStripMenuItem.Enabled = false;
                restoreToolStripMenuItem.Enabled = false;
                cambiarContraseñaToolStripMenuItem.Enabled = false;
            }
            else
            {
                unloginToolStripMenuItem.Enabled = true;
                backupToolStripMenuItem.Enabled = true;
                restoreToolStripMenuItem.Enabled = true;
                cambiarContraseñaToolStripMenuItem.Enabled = true;
            }
            administracionToolStripMenuItem.Visible = usuario is Be_Administrador;
            clientesToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Recepcionista;
            diagnosticoToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Mecanico || usuario is Be_JefeTaller;
            cobrosToolStripMenuItem.Visible = usuario is Be_Administrador || usuario is Be_Cajero;

        }

        #endregion

        #region Eventos de controles: reaccionan a selección, texto o cambios en pantalla

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ABMUsuario frmABM = new Form_ABMUsuario(usuariobll);
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
            CargarMenu(); 
            foreach (Form hijo in this.MdiChildren)
            {
                hijo.Close();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes(clientebll);
            formClientes.MdiParent = this;
            formClientes.WindowState = FormWindowState.Maximized;
            formClientes.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVehiculos frmVehiculos = new FormVehiculos(vehiculobll);
            frmVehiculos.MdiParent = this;
            frmVehiculos.WindowState = FormWindowState.Maximized;
            frmVehiculos.Show();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Turnos frmTurnos = new Form_Turnos(turnobll, clientebll, vehiculobll);
            frmTurnos.MdiParent = this;
            frmTurnos.WindowState = FormWindowState.Maximized;
            frmTurnos.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_BackupRestore frm = new Form_BackupRestore();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_BackupRestore frm = new Form_BackupRestore();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCambioContraseña frm = new FormCambioContraseña(usuariobll);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacoraEvento frm = new FormBitacoraEvento(bitacorabll);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        #endregion

        #region Métodos auxiliares: apoyo interno que no forma parte de la interfaz pública

        private void RegistrarEnBitacora(string descripcion, Be_Usuario usuario)
        {
            BE_BitacoraEvento evento = new BE_BitacoraEvento(DateTime.Now, DateTime.Now, usuario, descripcion);
            bitacorabll.RegistrarEvento(evento);
        }

        #endregion
    }
}
