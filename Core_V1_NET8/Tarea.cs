namespace Core_V1_NET8
{
    public enum NivelPrioridad
    {
        Urgente = 1,
        Importante = 2,
        Normal = 3
    }

    public class Tarea : IComparable<Tarea>
    {
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
        public TimeSpan HoraEntrega { get; set; }
        public NivelPrioridad Prioridad { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public int CompareTo(Tarea? otra)
        {
            if (otra is null)
            {
                return -1;
            }

            int comparacionPrioridad = Prioridad.CompareTo(otra.Prioridad);
            if (comparacionPrioridad != 0)
            {
                return comparacionPrioridad;
            }

            return FechaEntrega.CompareTo(otra.FechaEntrega);
        }
    }
}
