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
    /// RESPONSABILIDAD: Mostrar los eventos registrados en la bitácora.
    /// POR QUÉ EXISTE: Permite auditar qué hizo cada usuario.
    /// QUÉ NO HACE: No genera eventos.
    /// </summary>
    public partial class FormBitacoraEvento : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_Bitacora bllBitacora;

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public FormBitacoraEvento(BLL_Bitacora bllBitacoraCompartida)
        {
            InitializeComponent();
            bllBitacora = bllBitacoraCompartida;
        }

        #endregion

        #region Carga inicial: qué se prepara cuando se abre el formulario

        private void FormBitacoraEvento_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        #endregion

        #region Operaciones públicas: lo que otros formularios pueden pedirle a este

        public void ActualizarGrilla()
        {
            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = bllBitacora.ObtenerEventos();
            if (dgvBitacora.Columns["Horario"] != null)
                dgvBitacora.Columns["Horario"].DefaultCellStyle.Format = "HH:mm";
        }

        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
