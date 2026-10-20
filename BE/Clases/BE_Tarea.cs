using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    /// <summary>
    /// RESPONSABILIDAD: Vincular a un mecánico con una revisión general y llevar el estado de ese trabajo.
    /// POR QUÉ EXISTE: Separa "qué se revisa" (RevisionGeneral) de "quién lo hace y cómo va" (Tarea).
    /// QUÉ NO HACE: No asigna mecánicos por sí sola: la asignación es regla de negocio de la futura BLL.
    /// </summary>
    public class BE_Tarea
    {
        #region Datos de la entidad: propiedades que la describen

        public Be_Usuario MecanicoAsignado { get; set; }

        public string Estado { get; set; }

        public BE_RevisionGeneral RevisionGeneral { get; set; }

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        public BE_Tarea(Be_Usuario mecanicoAsignado, string estado, BE_RevisionGeneral revisionGeneral)
        {
            MecanicoAsignado = mecanicoAsignado;
            Estado = estado;
            RevisionGeneral = revisionGeneral;
        }

        #endregion
    }
}
