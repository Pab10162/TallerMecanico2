using System.Collections.Generic;

namespace BE
{
    public interface IABM<T>
    {
        void Alta(T entidad);
        void Baja(T entidad);
        void Modificacion(T entidad);
        List<T> ObtenerTodos();
    }
}