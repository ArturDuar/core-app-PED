using Core_V1_NET8.Models;

namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Árbol de prefijos (Trie) para búsqueda de tareas por prefijo de título
    /// en tiempo real. Todas las comparaciones se realizan en minúsculas para
    /// conseguir búsqueda insensible a mayúsculas.
    /// Restricción de diseño: no usa ninguna colección de System.Collections.Generic.
    /// </summary>
    public sealed class TrieTareas
    {
        private readonly NodoTrie raiz = new NodoTrie();

        // ── API PÚBLICA ────────────────────────────────────────────────────────

        /// <summary>
        /// Inserta el título de la tarea en el Trie y registra una referencia en
        /// cada nodo del camino para que la búsqueda por prefijo sea O(m).
        /// </summary>
        public void Insertar(string titulo, Tarea tarea)
        {
            if (string.IsNullOrEmpty(titulo)) return;

            string clave = titulo.ToLowerInvariant();
            NodoTrie actual = raiz;

            foreach (char c in clave)
            {
                actual = actual.ObtenerOCrearHijo(c);
                actual.AgregarTarea(tarea);
            }
        }

        /// <summary>
        /// Elimina la referencia a <paramref name="tarea"/> de todos los nodos
        /// del camino de <paramref name="titulo"/> y poda nodos huérfanos.
        /// </summary>
        public void Eliminar(string titulo, Tarea tarea)
        {
            if (string.IsNullOrEmpty(titulo)) return;
            EliminarRecursivo(raiz, titulo.ToLowerInvariant(), 0, tarea);
        }

        /// <summary>
        /// Devuelve todas las tareas cuyos títulos comienzan con
        /// <paramref name="prefijo"/>. Búsqueda O(m) donde m = longitud del prefijo.
        /// </summary>
        public Tarea[] BuscarPorPrefijo(string prefijo)
        {
            if (string.IsNullOrEmpty(prefijo)) return [];

            string clave = prefijo.ToLowerInvariant();
            NodoTrie actual = raiz;

            foreach (char c in clave)
            {
                NodoTrie? hijo = actual.ObtenerHijo(c);
                if (hijo is null) return [];
                actual = hijo;
            }

            return ExtraerTareas(actual);
        }

        // ── AUXILIARES PRIVADOS ───────────────────────────────────────────────

        private static Tarea[] ExtraerTareas(NodoTrie nodo)
        {
            int total = 0;
            NodoRefTarea? ref1 = nodo.TareasEnPrefijo;
            while (ref1 is not null) { total++; ref1 = ref1.Siguiente; }

            Tarea[] resultado = new Tarea[total];
            NodoRefTarea? refActual = nodo.TareasEnPrefijo;
            int i = 0;
            while (refActual is not null)
            {
                resultado[i++] = refActual.Tarea;
                refActual = refActual.Siguiente;
            }
            return resultado;
        }

        private static bool EliminarRecursivo(NodoTrie nodo, string clave, int nivel, Tarea tarea)
        {
            if (nivel == clave.Length)
            {
                nodo.EliminarTarea(tarea);
                return !nodo.TieneTareas() && nodo.EsHoja();
            }

            char c = clave[nivel];
            NodoTrie? hijo = nodo.ObtenerHijo(c);
            if (hijo is null) return false;

            bool eliminarHijo = EliminarRecursivo(hijo, clave, nivel + 1, tarea);

            if (eliminarHijo)
            {
                if (nodo.Hijos is not null && nodo.Hijos.Caracter == c)
                {
                    nodo.Hijos = nodo.Hijos.Siguiente;
                }
                else
                {
                    NodoHijoTrie? anterior = nodo.Hijos;
                    while (anterior?.Siguiente is not null)
                    {
                        if (anterior.Siguiente.Caracter == c)
                        {
                            anterior.Siguiente = anterior.Siguiente.Siguiente;
                            break;
                        }
                        anterior = anterior.Siguiente;
                    }
                }
            }

            nodo.EliminarTarea(tarea);
            return !nodo.TieneTareas() && nodo.EsHoja();
        }
    }
}
