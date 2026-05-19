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

            // Criterio 1 — Prioridad (menor valor enum = más urgente)
            int cmpPrioridad = Prioridad.CompareTo(otra.Prioridad);
            if (cmpPrioridad != 0) return cmpPrioridad;

            // Criterio 2 — Fecha+Hora de entrega combinadas (la más próxima gana)
            DateTime fechaHoraPropia = FechaEntrega.Date + HoraEntrega;
            DateTime fechaHoraOtra   = otra.FechaEntrega.Date + otra.HoraEntrega;
            int cmpFechaHora = fechaHoraPropia.CompareTo(fechaHoraOtra);
            if (cmpFechaHora != 0) return cmpFechaHora;

            // Criterio 3 — Id (la más antigua, Id menor, tiene mayor prioridad)
            return IdTarea.CompareTo(otra.IdTarea);
        }
    }
}
