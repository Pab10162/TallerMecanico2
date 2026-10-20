using System.Collections.Generic;

namespace BE
{
    /// <summary>
    /// RESPONSABILIDAD: Definir el contrato común Alta / Baja / Modificación / ObtenerTodos que cumplen las BLL.
    /// POR QUÉ EXISTE: Garantiza que todas las BLL se usen igual y que la UI pueda depender de la interfaz y no de una clase concreta.
    /// QUÉ NO HACE: No implementa nada: es solo el contrato.
    /// </summary>
    public interface IABM<T>
    {
        void Alta(T entidad);
        void Baja(T entidad);
        void Modificacion(T entidad);
        List<T> ObtenerTodos();
    }
}