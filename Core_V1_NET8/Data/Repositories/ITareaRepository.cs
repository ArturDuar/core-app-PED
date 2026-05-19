using Core_V1_NET8.Models;

namespace Core_V1_NET8.Data.Repositories
{
    /// <summary>
    /// Contrato de acceso a datos para <see cref="Tarea"/>.
    /// Ningún método devuelve colecciones de System.Collections.Generic;
    /// se usan arreglos primitivos (<c>Tarea[]</c>) como tipo de retorno colección.
    /// </summary>
    public interface ITareaRepository
    {
        /// <summary>Persiste la tarea y devuelve el ID autogenerado por la BD.</summary>
        int Insertar(Tarea tarea);

        /// <summary>Devuelve todas las tareas como arreglo primitivo.</summary>
        Tarea[] ObtenerTodas();

        /// <summary>Devuelve la tarea con el ID indicado, o <c>null</c> si no existe.</summary>
        Tarea? ObtenerPorId(int idTarea);

        /// <summary>Actualiza todos los campos de la tarea, incluido <see cref="Tarea.Completada"/>.</summary>
        void Actualizar(Tarea tarea);

        /// <summary>Elimina el registro con el ID indicado.</summary>
        void Eliminar(int idTarea);
    }
}
