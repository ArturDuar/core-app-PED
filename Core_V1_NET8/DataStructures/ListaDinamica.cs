namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Arreglo dinámico de propósito general que reemplaza a <c>List&lt;T&gt;</c>.
    /// Crece automáticamente duplicando su capacidad cuando se agota el espacio.
    /// Restricción de diseño: no usa ninguna colección de System.Collections.Generic.
    /// </summary>
    public class ListaDinamica<T>
    {
        private T[] elementos;

        public ListaDinamica(int capacidadInicial = 4)
        {
            if (capacidadInicial < 1) capacidadInicial = 4;
            elementos = new T[capacidadInicial];
            Count = 0;
        }

        public int Count { get; private set; }

        public T this[int indice]
        {
            get { ValidarIndice(indice); return elementos[indice]; }
            set { ValidarIndice(indice); elementos[indice] = value; }
        }

        public void Add(T item)
        {
            AsegurarCapacidad(Count + 1);
            elementos[Count] = item;
            Count++;
        }

        public void RemoveAt(int indice)
        {
            ValidarIndice(indice);
            for (int i = indice; i < Count - 1; i++)
                elementos[i] = elementos[i + 1];
            Count--;
            elementos[Count] = default!;
        }

        public ListaDinamica<T> Clone()
        {
            ListaDinamica<T> copia = new ListaDinamica<T>(Count);
            for (int i = 0; i < Count; i++)
                copia.Add(elementos[i]);
            return copia;
        }

        private void ValidarIndice(int indice)
        {
            if (indice < 0 || indice >= Count)
                throw new ArgumentOutOfRangeException(nameof(indice));
        }

        private void AsegurarCapacidad(int capacidadNecesaria)
        {
            if (capacidadNecesaria <= elementos.Length) return;

            int nuevaCapacidad = elementos.Length * 2;
            if (nuevaCapacidad < capacidadNecesaria) nuevaCapacidad = capacidadNecesaria;

            T[] nuevoArreglo = new T[nuevaCapacidad];
            for (int i = 0; i < Count; i++)
                nuevoArreglo[i] = elementos[i];
            elementos = nuevoArreglo;
        }
    }
}
