using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Enumerar los niveles de urgencia posibles de un diagnóstico.
    /// POR QUÉ EXISTE: Un enum evita strings sueltos ("alta", "Alta ", "ALTA") que se escriben distinto y rompen comparaciones.
    /// QUÉ NO HACE: No tiene lógica asociada.
    /// </summary>
    public enum Urgencia
    {
        Alta,
        Media, 
        Baja
    }
}
