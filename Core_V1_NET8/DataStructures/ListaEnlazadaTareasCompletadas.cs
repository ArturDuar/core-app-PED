using Core_V1_NET8.Models;

namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Lista enlazada simple que actúa como pila: las tareas completadas más
    /// recientes se insertan al inicio, de modo que <c>ObtenerLista</c> devuelve
    /// los elementos de más reciente a más antiguo.
    /// Restricción de diseño: no usa ninguna colección de System.Collections.Generic.
    /// </summary>
    public sealed class ListaEnlazadaTareasCompletadas
    {
        private NodoTareaCompletada? cabeza;

        /// <summary>Cantidad de tareas completadas almacenadas.</summary>
        public int Count { get; private set; }

        // ── OPERACIONES PRINCIPALES ────────────────────────────────────────────

        /// <summary>Inserta una tarea completada al inicio de la lista (orden LIFO).</summary>
        public void AgregarAlInicio(Tarea tarea)
        {
            NodoTareaCompletada nuevo = new NodoTareaCompletada(tarea)
            {
                Siguiente = cabeza
            };
            cabeza = nuevo;
            Count++;
        }

        /// <summary>
        /// Elimina la primera ocurrencia cuyo <see cref="Tarea.IdTarea"/> coincida.
        /// </summary>
        /// <returns><c>true</c> si se encontró y eliminó; <c>false</c> en caso contrario.</returns>
        public bool Eliminar(Tarea tarea)
        {
            if (cabeza is null) return false;

            if (cabeza.Dato.IdTarea == tarea.IdTarea)
            {
                cabeza = cabeza.Siguiente;
                Count--;
                return true;
            }

            NodoTareaCompletada actual = cabeza;
            while (actual.Siguiente is not null)
            {
                if (actual.Siguiente.Dato.IdTarea == tarea.IdTarea)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    Count--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        /// <summary>
        /// Busca y devuelve la tarea por ID sin eliminarla.
        /// Devuelve <c>null</c> si no existe.
        /// </summary>
        public Tarea? BuscarPorId(int id)
        {
            NodoTareaCompletada? actual = cabeza;
            while (actual is not null)
            {
                if (actual.Dato.IdTarea == id) return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        /// <summary>
        /// Devuelve un arreglo con todas las tareas completadas en orden de
        /// inserción (más reciente primero).
        /// </summary>
        public Tarea[] ObtenerLista()
        {
            Tarea[] resultado = new Tarea[Count];
            NodoTareaCompletada? actual = cabeza;
            int indice = 0;

            while (actual is not null)
            {
                resultado[indice++] = actual.Dato;
                actual = actual.Siguiente;
            }
            return resultado;
        }
    }
}
