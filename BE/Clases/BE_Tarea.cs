using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Clases
{
    public class BE_Tarea
    {
        public BE_Tarea(Be_Usuario mecanicoAsignado, string estado, BE_RevisionGeneral revisionGeneral)
        {
            MecanicoAsignado = mecanicoAsignado;
            Estado = estado;
            RevisionGeneral = revisionGeneral;
        }

        public Be_Usuario MecanicoAsignado { get; set; }
        public string Estado { get; set; }
        public BE_RevisionGeneral RevisionGeneral { get; set; }

    }
}
