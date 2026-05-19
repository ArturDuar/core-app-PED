using Core_V1_NET8.Models;

namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Nodo del Trie. Mantiene una lista enlazada de hijos (por carácter) y una
    /// lista enlazada de tareas que tienen este prefijo como parte de su título.
    /// </summary>
    internal sealed class NodoTrie
    {
        /// <summary>Lista enlazada de pares (carácter → NodoTrie hijo).</summary>
        public NodoHijoTrie?  Hijos           { get; set; }

        /// <summary>
        /// Referencias a las tareas cuyo título pasa por este nodo.
        /// Se agregan en cada nivel del camino para permitir búsqueda O(m) por prefijo.
        /// </summary>
        public NodoRefTarea?  TareasEnPrefijo { get; set; }

        // ── Hijos ──────────────────────────────────────────────────────────────

        /// <summary>Devuelve el nodo hijo asociado al carácter dado, o <c>null</c>.</summary>
        public NodoTrie? ObtenerHijo(char c)
        {
            NodoHijoTrie? actual = Hijos;
            while (actual is not null)
            {
                if (actual.Caracter == c) return actual.Hijo;
                actual = actual.Siguiente;
            }
            return null;
        }

        /// <summary>Devuelve el nodo hijo para el carácter dado; si no existe, lo crea.</summary>
        public NodoTrie ObtenerOCrearHijo(char c)
        {
            NodoHijoTrie? actual = Hijos;
            while (actual is not null)
            {
                if (actual.Caracter == c) return actual.Hijo;
                actual = actual.Siguiente;
            }

            NodoTrie nuevoNodo = new NodoTrie();
            Hijos = new NodoHijoTrie(c, nuevoNodo) { Siguiente = Hijos };
            return nuevoNodo;
        }

        /// <summary>Indica si el nodo no tiene hijos.</summary>
        public bool EsHoja() => Hijos is null;

        // ── Referencias a tareas ───────────────────────────────────────────────

        /// <summary>Agrega una referencia a una tarea en este nodo (evita duplicados por IdTarea).</summary>
        public void AgregarTarea(Tarea tarea)
        {
            NodoRefTarea? actual = TareasEnPrefijo;
            while (actual is not null)
            {
                if (actual.Tarea.IdTarea == tarea.IdTarea) return;
                actual = actual.Siguiente;
            }
            TareasEnPrefijo = new NodoRefTarea(tarea) { Siguiente = TareasEnPrefijo };
        }

        /// <summary>Elimina la referencia a una tarea en este nodo.</summary>
        public void EliminarTarea(Tarea tarea)
        {
            if (TareasEnPrefijo is null) return;

            if (TareasEnPrefijo.Tarea.IdTarea == tarea.IdTarea)
            {
                TareasEnPrefijo = TareasEnPrefijo.Siguiente;
                return;
            }

            NodoRefTarea actual = TareasEnPrefijo;
            while (actual.Siguiente is not null)
            {
                if (actual.Siguiente.Tarea.IdTarea == tarea.IdTarea)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }
        }

        /// <summary>Indica si este nodo tiene alguna tarea referenciada.</summary>
        public bool TieneTareas() => TareasEnPrefijo is not null;
    }
}
