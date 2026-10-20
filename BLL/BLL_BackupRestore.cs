// BLL/BLL_BackupRestore.cs
using DAL;

namespace BLL
{
    /// <summary>
    /// RESPONSABILIDAD: Coordinar el backup y restore de la base.
    /// POR QUÉ EXISTE: Mantiene a la UI sin conocer la DAL (la UI nunca habla con la DAL directamente).
    /// QUÉ NO HACE: No presenta diálogos ni elige archivos.
    /// </summary>
    public class BLL_BackupRestore
    {
        private DAL_BackupRestore dal = new DAL_BackupRestore();

        public void RealizarBackup(string ruta)
        {
            dal.RealizarBackup(ruta);
        }

        public void RealizarRestore(string ruta)
        {
            dal.RealizarRestore(ruta);
        }
    }
}