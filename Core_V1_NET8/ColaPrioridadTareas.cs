namespace Core_V1_NET8
{
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

        public void Encolar(Tarea nuevaTarea)
        {
            monticulo.Add(nuevaTarea);
            Flotar(monticulo.Count - 1);
        }

        public Tarea Desencolar()
        {
            if (monticulo.Count == 0)
            {
                throw new InvalidOperationException("La cola está vacía.");
            }

            Tarea tareaUrgente = monticulo[0];
            monticulo[0] = monticulo[monticulo.Count - 1];
            monticulo.RemoveAt(monticulo.Count - 1);

            if (monticulo.Count > 0)
            {
                Hundir(0);
            }

            return tareaUrgente;
        }

        public Tarea? ObtenerMasUrgente()
        {
            if (monticulo.Count == 0)
            {
                return null;
            }

            return monticulo[0];
        }

        private void Flotar(int indice)
        {
            while (indice > 0)
            {
                int indicePadre = (indice - 1) / 2;
                if (monticulo[indice].CompareTo(monticulo[indicePadre]) >= 0)
                {
                    break;
                }

                Intercambiar(indice, indicePadre);
                indice = indicePadre;
            }
        }

        private void Hundir(int indice)
        {
            int ultimoIndice = monticulo.Count - 1;
            while (true)
            {
                int hijoIzquierdo = 2 * indice + 1;
                int hijoDerecho = 2 * indice + 2;
                int menor = indice;

                if (hijoIzquierdo <= ultimoIndice && monticulo[hijoIzquierdo].CompareTo(monticulo[menor]) < 0)
                {
                    menor = hijoIzquierdo;
                }

                if (hijoDerecho <= ultimoIndice && monticulo[hijoDerecho].CompareTo(monticulo[menor]) < 0)
                {
                    menor = hijoDerecho;
                }

                if (menor == indice)
                {
                    break;
                }

                Intercambiar(indice, menor);
                indice = menor;
            }
        }

        private void Intercambiar(int i, int j)
        {
            Tarea temp = monticulo[i];
            monticulo[i] = monticulo[j];
            monticulo[j] = temp;
        }

        public ListaDinamica<Tarea> ObtenerTodas()
        {
            ColaPrioridadTareas copiaCola = new ColaPrioridadTareas(monticulo.Clone());
            ListaDinamica<Tarea> ordenadas = new ListaDinamica<Tarea>(monticulo.Count);

            while (copiaCola.monticulo.Count > 0)
            {
                ordenadas.Add(copiaCola.Desencolar());
            }

            return ordenadas;
        }
    }
}
