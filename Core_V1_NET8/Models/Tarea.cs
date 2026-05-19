namespace Core_V1_NET8.Models
{
    /// <summary>
    /// Entidad principal del dominio. Representa una tarea con título, fecha de
    /// entrega, prioridad, descripción y estado de completado.
    /// Implementa <see cref="IComparable{Tarea}"/> para que el Min-Heap pueda
    /// ordenar las tareas sin depender de colecciones externas.
    /// </summary>
    public class Tarea : IComparable<Tarea>
    {
        public int           IdTarea      { get; set; }
        public string        Titulo       { get; set; } = string.Empty;
        public DateTime      FechaEntrega { get; set; }
        public TimeSpan      HoraEntrega  { get; set; }
        public NivelPrioridad Prioridad   { get; set; }
        public string        Descripcion  { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la tarea fue marcada como completada.
        /// Las tareas completadas van a <c>ListaEnlazadaTareasCompletadas</c>;
        /// las pendientes, al Min-Heap de prioridad.
        /// </summary>
        public bool Completada { get; set; }

        public int CompareTo(Tarea? otra)
        {
            if (otra is null) return -1;

            int comparacionPrioridad = Prioridad.CompareTo(otra.Prioridad);
            if (comparacionPrioridad != 0) return comparacionPrioridad;

            return FechaEntrega.CompareTo(otra.FechaEntrega);
        }
    }
}
