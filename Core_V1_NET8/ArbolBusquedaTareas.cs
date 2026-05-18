using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_V1_NET8
{
    public class NodoArbol
    {
        public Tarea Valor { get; set; }
        public NodoArbol? Izquierdo { get; set; }
        public NodoArbol? Derecho { get; set; }

        public NodoArbol(Tarea tarea)
        {
            Valor = tarea;
            Izquierdo = null;
            Derecho = null;
        }
    }

    public class ArbolBusquedaTareas
    {
        public NodoArbol? Raiz { get; private set; }

        public ArbolBusquedaTareas()
        {
            Raiz = null;
        }

        public void Insertar(Tarea nuevaTarea)
        {
            Raiz = InsertarRecursivo(Raiz, nuevaTarea);
        }

        private NodoArbol InsertarRecursivo(NodoArbol? actual, Tarea nuevaTarea)
        {
            if (actual == null)
            {
                return new NodoArbol(nuevaTarea);
            }

            // Comparación alfabética ignorando mayúsculas y minúsculas
            int comparacion = string.Compare(nuevaTarea.Titulo, actual.Valor.Titulo, StringComparison.OrdinalIgnoreCase);

            if (comparacion < 0)
            {
                actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, nuevaTarea);
            }
            else
            {
                // Si es mayor o igual, se almacena en el subárbol derecho
                actual.Derecho = InsertarRecursivo(actual.Derecho, nuevaTarea);
            }

            return actual;
        }

        public ListaDinamica<Tarea> BuscarPorPrefijo(string textoBusqueda)
        {
            ListaDinamica<Tarea> resultados = new ListaDinamica<Tarea>();
            BuscarContenidoRecursivo(Raiz, textoBusqueda, resultados);
            return resultados;
        }

        private void BuscarContenidoRecursivo(NodoArbol? actual, string textoBusqueda, ListaDinamica<Tarea> resultados)
        {
            if (actual == null) return;

            // Recorremos primero el subárbol izquierdo (mantiene el orden alfabético en los resultados)
            BuscarContenidoRecursivo(actual.Izquierdo, textoBusqueda, resultados);

            // Evaluamos si el título contiene la palabra o texto ingresado en cualquier posición
            if (actual.Valor.Titulo.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
            {
                resultados.Add(actual.Valor);
            }

            // Recorremos el subárbol derecho
            BuscarContenidoRecursivo(actual.Derecho, textoBusqueda, resultados);
        }

        private void BuscarPorPrefijoRecursivo(NodoArbol? actual, string prefijo, ListaDinamica<Tarea> resultados)
        {
            if (actual == null) return;

            // Evalúa si el título del nodo actual comienza con el texto digitado
            if (actual.Valor.Titulo.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
            {
                // Al coincidir por prefijo, los elementos válidos pueden estar a ambos lados.
                // Hacemos un recorrido En-Orden para mantener el resultado alfabético.
                BuscarPorPrefijoRecursivo(actual.Izquierdo, prefijo, resultados);
                resultados.Add(actual.Valor);
                BuscarPorPrefijoRecursivo(actual.Derecho, prefijo, resultados);
            }
            else
            {
                // Si no coincide, decidimos la ruta de exploración alfabéticamente
                int comparacion = string.Compare(prefijo, actual.Valor.Titulo, StringComparison.OrdinalIgnoreCase);

                if (comparacion < 0)
                {
                    BuscarPorPrefijoRecursivo(actual.Izquierdo, prefijo, resultados);
                }
                else
                {
                    BuscarPorPrefijoRecursivo(actual.Derecho, prefijo, resultados);
                }
            }
        }

        public ListaDinamica<Tarea> ObtenerEnOrden()
        {
            ListaDinamica<Tarea> lista = new ListaDinamica<Tarea>();
            RecorridoEnOrden(Raiz, lista);
            return lista;
        }

        private void RecorridoEnOrden(NodoArbol? actual, ListaDinamica<Tarea> lista)
        {
            if (actual != null)
            {
                RecorridoEnOrden(actual.Izquierdo, lista);
                lista.Add(actual.Valor);
                RecorridoEnOrden(actual.Derecho, lista);
            }
        }


    }
}
