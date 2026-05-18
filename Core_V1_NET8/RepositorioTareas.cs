using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Core_V1_NET8
{
    public class RepositorioTareas
    {
        // se dejo "localhost" como nombre del servidor
        private readonly string cadenaConexion = "Server=localhost;Database=GestorTareasCore;Trusted_Connection=True;TrustServerCertificate=True;";

        // Método para guardar una nueva tarea
        public void GuardarTarea(Tarea tarea)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = @"INSERT INTO Tareas (Titulo, Descripcion, FechaEntrega, HoraEntrega, Prioridad, Completada) 
                                 VALUES (@Titulo, @Descripcion, @FechaEntrega, @HoraEntrega, @Prioridad, 0)";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                    comando.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                    comando.Parameters.AddWithValue("@FechaEntrega", tarea.FechaEntrega);
                    comando.Parameters.AddWithValue("@HoraEntrega", tarea.HoraEntrega);
                    comando.Parameters.AddWithValue("@Prioridad", (int)tarea.Prioridad);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
