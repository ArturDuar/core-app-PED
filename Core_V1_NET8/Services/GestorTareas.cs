using Core_V1_NET8.DataStructures;
using Core_V1_NET8.Data.Repositories;
using Core_V1_NET8.Models;

namespace Core_V1_NET8.Services
{
    /// <summary>
    /// Fachada de lógica de negocio que mantiene sincronizadas la base de datos
    /// y las estructuras de datos en memoria (Min-Heap, Lista Enlazada, Trie).
    /// <para>
    /// Restricción de diseño: no se usa ninguna colección de
    /// <c>System.Collections.Generic</c>.
    /// </para>
    /// </summary>
    public sealed class GestorTareas
    {
        // ── DEPENDENCIAS ──────────────────────────────────────────────────────
        private readonly ITareaRepository repositorio;

        // ── ESTRUCTURAS EN MEMORIA ────────────────────────────────────────────

        /// <summary>Tareas pendientes ordenadas por prioridad y fecha (Min-Heap).</summary>
        private readonly ColaPrioridadTareas heap;

        /// <summary>Tareas completadas en orden de más reciente a más antigua.</summary>
        private readonly ListaEnlazadaTareasCompletadas listaCompletadas;

        /// <summary>Índice de prefijos para búsqueda en tiempo real (solo tareas pendientes).</summary>
        private readonly TrieTareas trie;

        // ── CONSTRUCTOR ───────────────────────────────────────────────────────

        public GestorTareas(ITareaRepository repositorio)
        {
            this.repositorio = repositorio;
            heap             = new ColaPrioridadTareas();
            listaCompletadas = new ListaEnlazadaTareasCompletadas();
            trie             = new TrieTareas();
        }

        // ── 1. CARGA INICIAL ──────────────────────────────────────────────────

        /// <summary>
        /// Lee todas las tareas de la base de datos y las distribuye en las
        /// estructuras de memoria según su estado (<see cref="Tarea.Completada"/>).
        /// Debe llamarse una única vez al arrancar la aplicación.
        /// </summary>
        public void CargarDatosIniciales()
        {
            Tarea[] tareas = repositorio.ObtenerTodas();

            for (int i = 0; i < tareas.Length; i++)
            {
                Tarea t = tareas[i];
                if (t.Completada)
                    listaCompletadas.AgregarAlInicio(t);
                else
                {
                    heap.Insertar(t);
                    trie.Insertar(t.Titulo, t);
                }
            }
        }

        // ── 2. AGREGAR ────────────────────────────────────────────────────────

        /// <summary>
        /// Persiste la nueva tarea en la BD (asignando el ID generado) y la
        /// incorpora al Min-Heap y al Trie.
        /// </summary>
        public void AgregarTarea(Tarea nuevaTarea)
        {
            repositorio.Insertar(nuevaTarea);
            heap.Insertar(nuevaTarea);
            trie.Insertar(nuevaTarea.Titulo, nuevaTarea);
        }

        // ── 3. EDITAR ─────────────────────────────────────────────────────────

        /// <summary>
        /// Actualiza la tarea en la BD y sincroniza las estructuras en memoria.
        /// </summary>
        /// <param name="tareaEditada">Objeto con los nuevos valores.</param>
        /// <param name="tituloAnterior">Título que tenía la tarea antes de editar.</param>
        public void EditarTarea(Tarea tareaEditada, string tituloAnterior)
        {
            repositorio.Actualizar(tareaEditada);

            if (!tareaEditada.Completada)
            {
                heap.EliminarPorId(tareaEditada.IdTarea);
                heap.Insertar(tareaEditada);

                Tarea proxyViejo = new Tarea { IdTarea = tareaEditada.IdTarea, Titulo = tituloAnterior };
                trie.Eliminar(tituloAnterior, proxyViejo);
                trie.Insertar(tareaEditada.Titulo, tareaEditada);
            }
        }

        // ── 4. MARCAR COMO COMPLETADA ─────────────────────────────────────────

        /// <summary>
        /// Mueve la tarea del Min-Heap/Trie a la Lista de Completadas y persiste.
        /// </summary>
        public Tarea? MarcarComoCompletada(int idTarea)
        {
            Tarea? tarea = heap.BuscarPorId(idTarea);
            if (tarea is null) return null;

            heap.EliminarPorId(idTarea);
            trie.Eliminar(tarea.Titulo, tarea);

            tarea.Completada = true;
            repositorio.Actualizar(tarea);

            listaCompletadas.AgregarAlInicio(tarea);
            return tarea;
        }

        // ── 5. DESMARCAR COMPLETADA ───────────────────────────────────────────

        /// <summary>
        /// Mueve la tarea de la Lista de Completadas al Min-Heap/Trie y persiste.
        /// </summary>
        public Tarea? DesmarcarCompletada(int idTarea)
        {
            Tarea? tarea = listaCompletadas.BuscarPorId(idTarea);
            if (tarea is null) return null;

            listaCompletadas.Eliminar(tarea);

            tarea.Completada = false;
            repositorio.Actualizar(tarea);

            heap.Insertar(tarea);
            trie.Insertar(tarea.Titulo, tarea);
            return tarea;
        }

        // ── 6. ELIMINAR ───────────────────────────────────────────────────────

        /// <summary>
        /// Elimina la tarea de la BD y de la estructura en memoria que la contenga.
        /// </summary>
        public bool EliminarTarea(int idTarea)
        {
            Tarea? enHeap = heap.BuscarPorId(idTarea);
            if (enHeap is not null)
            {
                repositorio.Eliminar(idTarea);
                heap.EliminarPorId(idTarea);
                trie.Eliminar(enHeap.Titulo, enHeap);
                return true;
            }

            Tarea? enLista = listaCompletadas.BuscarPorId(idTarea);
            if (enLista is not null)
            {
                repositorio.Eliminar(idTarea);
                listaCompletadas.Eliminar(enLista);
                return true;
            }

            return false;
        }

        // ── 7. CONSULTAS PARA LA UI ───────────────────────────────────────────

        /// <summary>Devuelve la tarea de mayor prioridad sin extraerla del Heap.</summary>
        public Tarea? ObtenerTareaMasUrgente() => heap.ObtenerMasUrgente();

        /// <summary>
        /// Devuelve todas las tareas pendientes como arreglo primitivo en orden
        /// de prioridad (Urgente → Normal), sin modificar el Heap.
        /// </summary>
        public Tarea[] ObtenerTareasPendientes()
        {
            ListaDinamica<Tarea> ordenadas = heap.ObtenerTodas();
            return ConvertirAArreglo(ordenadas);
        }

        /// <summary>Devuelve todas las tareas completadas (más reciente primero).</summary>
        public Tarea[] ObtenerTareasCompletadas() => listaCompletadas.ObtenerLista();

        /// <summary>
        /// Busca tareas pendientes cuyo título comience con <paramref name="prefijo"/>
        /// (insensible a mayúsculas).
        /// </summary>
        public Tarea[] Buscar(string prefijo) => trie.BuscarPorPrefijo(prefijo);

        // ── AUXILIAR PRIVADO ──────────────────────────────────────────────────

        private static Tarea[] ConvertirAArreglo(ListaDinamica<Tarea> lista)
        {
            Tarea[] resultado = new Tarea[lista.Count];
            for (int i = 0; i < lista.Count; i++)
                resultado[i] = lista[i];
            return resultado;
        }
    }
}
