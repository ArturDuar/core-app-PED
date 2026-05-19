namespace Core_V1_NET8.Models
{
    /// <summary>
    /// Niveles de prioridad disponibles para una tarea.
    /// Los valores enteros determinan el orden en el Min-Heap:
    /// un número menor equivale a mayor urgencia.
    /// </summary>
    public enum NivelPrioridad
    {
        Urgente    = 1,
        Importante = 2,
        Normal     = 3
    }
}
