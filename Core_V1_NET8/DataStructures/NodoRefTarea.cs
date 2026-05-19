using Core_V1_NET8.Models;

namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Nodo de la lista enlazada que almacena referencias a <see cref="Tarea"/>
    /// dentro de cada nodo del Trie. Permite devolver resultados de búsqueda
    /// sin recorrido adicional del árbol.
    /// </summary>
    internal sealed class NodoRefTarea
    {
        public Tarea          Tarea     { get; set; }
        public NodoRefTarea?  Siguiente { get; set; }

        public NodoRefTarea(Tarea tarea)
        {
            Tarea     = tarea;
            Siguiente = null;
        }
    }
}
