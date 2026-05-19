using Core_V1_NET8.Models;

namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Nodo de la lista enlazada simple para tareas completadas.
    /// Almacena la tarea y la referencia al siguiente nodo.
    /// </summary>
    internal sealed class NodoTareaCompletada
    {
        public Tarea                  Dato      { get; set; }
        public NodoTareaCompletada?   Siguiente { get; set; }

        public NodoTareaCompletada(Tarea dato)
        {
            Dato      = dato;
            Siguiente = null;
        }
    }
}
