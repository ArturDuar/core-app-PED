namespace Core_V1_NET8.DataStructures
{
    /// <summary>
    /// Nodo de la tabla de hijos del Trie. Almacena una dupla (carácter → nodo hijo).
    /// Se implementa como lista enlazada de pares para evitar colecciones de .NET.
    /// </summary>
    internal sealed class NodoHijoTrie
    {
        public char           Caracter  { get; set; }
        public NodoTrie       Hijo      { get; set; }
        public NodoHijoTrie?  Siguiente { get; set; }

        public NodoHijoTrie(char caracter, NodoTrie hijo)
        {
            Caracter  = caracter;
            Hijo      = hijo;
            Siguiente = null;
        }
    }
}
