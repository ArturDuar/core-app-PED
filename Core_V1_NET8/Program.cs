using Core_V1_NET8.UI;

namespace Core_V1_NET8
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}