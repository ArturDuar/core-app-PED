using Core_V1_NET8.Models;

namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Min-Heap de tareas pendientes. La tarea con menor valor de
    /// <see cref="NivelPrioridad"/> (más urgente) y, en caso de empate, con la
    /// fecha más próxima, se mantiene siempre en la raíz del montículo.
    /// Restricción de diseño: no usa ninguna colección de System.Collections.Generic.
    /// </summary>
    public class ColaPrioridadTareas
    {
        private readonly ListaDinamica<Tarea> monticulo;

        public ColaPrioridadTareas()
        {
            monticulo = new ListaDinamica<Tarea>();
        }

        private ColaPrioridadTareas(ListaDinamica<Tarea> monticuloInicial)
        {
            monticulo = monticuloInicial;
        }

        /// <summary>Inserta una nueva tarea en el montículo y reordena hacia arriba.</summary>
        public void Insertar(Tarea nuevaTarea) => Encolar(nuevaTarea);

        public void Encolar(Tarea nuevaTarea)
        {
            monticulo.Add(nuevaTarea);
            Flotar(monticulo.Count - 1);
        }

        /// <summary>Extrae y devuelve la tarea de mayor prioridad (mínimo valor de NivelPrioridad).</summary>
        public Tarea ExtraerMinimo() => Desencolar();

        public Tarea Desencolar()
        {
            if (monticulo.Count == 0)
                throw new InvalidOperationException("La cola está vacía.");

            Tarea tareaUrgente = monticulo[0];
            monticulo[0] = monticulo[monticulo.Count - 1];
            monticulo.RemoveAt(monticulo.Count - 1);

            if (monticulo.Count > 0) Hundir(0);

            return tareaUrgente;
        }

        /// <summary>Devuelve el elemento en la posición dada dentro del arreglo interno.</summary>
        public Tarea ObtenerElemento(int indice) => monticulo[indice];

        /// <summary>Elimina del montículo la primera tarea cuyo IdTarea coincida.</summary>
        public bool EliminarPorId(int id)
        {
            int posicion = -1;
            for (int i = 0; i < monticulo.Count; i++)
            {
                if (monticulo[i].IdTarea == id) { posicion = i; break; }
            }
            if (posicion == -1) return false;

            monticulo[posicion] = monticulo[monticulo.Count - 1];
            monticulo.RemoveAt(monticulo.Count - 1);

            if (posicion < monticulo.Count)
            {
                Flotar(posicion);
                Hundir(posicion);
            }
            return true;
        }

        /// <summary>Busca sin extraer. Devuelve <c>null</c> si no existe.</summary>
        public Tarea? BuscarPorId(int id)
        {
            for (int i = 0; i < monticulo.Count; i++)
                if (monticulo[i].IdTarea == id) return monticulo[i];
            return null;
        }

        /// <summary>Cantidad de tareas en el montículo.</summary>
        public int Count => monticulo.Count;

        /// <summary>Devuelve la tarea más urgente sin extraerla; <c>null</c> si está vacío.</summary>
        public Tarea? ObtenerMasUrgente() => monticulo.Count == 0 ? null : monticulo[0];

        private void Flotar(int indice)
        {
            while (indice > 0)
            {
                int indicePadre = (indice - 1) / 2;
                if (((IComparable<Tarea>)monticulo[indice]).CompareTo(monticulo[indicePadre]) >= 0) break;
                Intercambiar(indice, indicePadre);
                indice = indicePadre;
            }
        }

        private void Hundir(int indice)
        {
            int ultimoIndice = monticulo.Count - 1;
            while (true)
            {
                int hijoIzq = 2 * indice + 1;
                int hijoDer = 2 * indice + 2;
                int menor   = indice;

                if (hijoIzq <= ultimoIndice && ((IComparable<Tarea>)monticulo[hijoIzq]).CompareTo(monticulo[menor]) < 0)
                    menor = hijoIzq;
                if (hijoDer <= ultimoIndice && ((IComparable<Tarea>)monticulo[hijoDer]).CompareTo(monticulo[menor]) < 0)
                    menor = hijoDer;

                if (menor == indice) break;

                Intercambiar(indice, menor);
                indice = menor;
            }
        }

        private void Intercambiar(int i, int j)
        {
            Tarea temp   = monticulo[i];
            monticulo[i] = monticulo[j];
            monticulo[j] = temp;
        }

        /// <summary>
        /// Devuelve todas las tareas en orden de prioridad extrayendo de una copia
        /// del montículo, sin modificar el original.
        /// </summary>
        public ListaDinamica<Tarea> ObtenerTodas()
        {
            ColaPrioridadTareas copiaCola = new ColaPrioridadTareas(monticulo.Clone());
            ListaDinamica<Tarea> ordenadas = new ListaDinamica<Tarea>(monticulo.Count);

            while (copiaCola.monticulo.Count > 0)
                ordenadas.Add(copiaCola.Desencolar());

            return ordenadas;
        }
    }
}
