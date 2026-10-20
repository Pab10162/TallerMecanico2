using BLL;
using System;
using System.Windows.Forms;

namespace UI.BackUpRestore
{
    /// <summary>
    /// RESPONSABILIDAD: Pedir la ruta y disparar un backup o restore de la base.
    /// POR QUÉ EXISTE: Es la interfaz de una operación crítica del sistema.
    /// QUÉ NO HACE: No ejecuta el backup: delega en BLL_BackupRestore.
    /// </summary>
    public partial class Form_BackupRestore : Form
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        BLL_BackupRestore bllBackupRestore = new BLL_BackupRestore();

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public Form_BackupRestore()
        {
            InitializeComponent();
        }

        #endregion

        #region Botones: cada clic se traduce en una acción; las reglas de negocio viven en la BLL

        private void btnBackup_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuta.Text))
            {
                MessageBox.Show("Debe elegir la ruta donde se guardará el backup (botón Browser)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bllBackupRestore.RealizarBackup(txtRuta.Text);
                MessageBox.Show("Backup realizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al realizar el backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowser_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = saveFileDialog1.FileName;
            }
        }

        private void btnRestore_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccionar archivo de backup a restaurar";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return; // el usuario canceló, no hace nada más
                }

                string rutaRestore = openFileDialog.FileName;

                DialogResult confirmacion = MessageBox.Show(
                    $"Se restaurará la base de datos desde:\n{rutaRestore}\n\nEsto sobrescribirá los datos actuales. ¿Desea continuar?",
                    "Confirmar Restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    bllBackupRestore.RealizarRestore(rutaRestore);
                    MessageBox.Show("Restore realizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al realizar el restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}