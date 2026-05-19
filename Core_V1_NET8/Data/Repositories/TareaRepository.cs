using Core_V1_NET8.Data.Database;
using Core_V1_NET8.DataStructures;
using Core_V1_NET8.Models;
using Microsoft.Data.SqlClient;

namespace Core_V1_NET8.Data.Repositories
{
    /// <summary>
    /// Implementación ADO.NET puro del repositorio de tareas.
    /// <para>
    /// Restricción de diseño: no se usa ninguna colección de
    /// <c>System.Collections.Generic</c>. El método <see cref="ObtenerTodas"/>
    /// acumula resultados en un <see cref="ListaDinamica{T}"/> (Fase 1) y devuelve
    /// un arreglo primitivo <c>Tarea[]</c>.
    /// </para>
    /// </summary>
    public sealed class TareaRepository : ITareaRepository
    {
        // ── ÍNDICES DE COLUMNA (coinciden con el ORDER del SELECT) ─────────────
        private const int ColIdTarea      = 0;
        private const int ColTitulo       = 1;
        private const int ColDescripcion  = 2;
        private const int ColFechaEntrega = 3;
        private const int ColHoraEntrega  = 4;
        private const int ColPrioridad    = 5;
        private const int ColCompletada   = 6;

        // ── INSERTAR ──────────────────────────────────────────────────────────

        /// <inheritdoc/>
        public int Insertar(Tarea tarea)
        {
            const string sql = @"
                INSERT INTO dbo.Tareas
                    (Titulo, Descripcion, FechaEntrega, HoraEntrega, Prioridad, Completada)
                VALUES
                    (@Titulo, @Descripcion, @FechaEntrega, @HoraEntrega, @Prioridad, @Completada);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);

            AgregarParametrosTarea(cmd, tarea);
            conn.Open();

            object? scalar = cmd.ExecuteScalar();
            int nuevoId = scalar is not null ? Convert.ToInt32(scalar) : 0;
            tarea.IdTarea = nuevoId;
            return nuevoId;
        }

        // ── OBTENER TODAS ─────────────────────────────────────────────────────

        /// <inheritdoc/>
        /// <remarks>
        /// Usa <see cref="ListaDinamica{T}"/> para acumular sin recurrir a
        /// <c>List&lt;T&gt;</c> y retorna un arreglo primitivo <c>Tarea[]</c>.
        /// El ORDER BY garantiza que al poblar el Min-Heap desde este arreglo
        /// el gestor de estado itere en orden natural.
        /// </remarks>
        public Tarea[] ObtenerTodas()
        {
            const string sql = @"
                SELECT IdTarea, Titulo, Descripcion, FechaEntrega, HoraEntrega, Prioridad, Completada
                FROM dbo.Tareas
                ORDER BY Prioridad ASC, FechaEntrega ASC;";

            ListaDinamica<Tarea> buffer = new ListaDinamica<Tarea>();

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                buffer.Add(LeerTarea(reader));
            }

            return ConvertirAArreglo(buffer);
        }

        // ── OBTENER POR ID ────────────────────────────────────────────────────

        /// <inheritdoc/>
        public Tarea? ObtenerPorId(int idTarea)
        {
            const string sql = @"
                SELECT IdTarea, Titulo, Descripcion, FechaEntrega, HoraEntrega, Prioridad, Completada
                FROM dbo.Tareas
                WHERE IdTarea = @IdTarea;";

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(new SqlParameter("@IdTarea", System.Data.SqlDbType.Int) { Value = idTarea });

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            return reader.Read() ? LeerTarea(reader) : null;
        }

        // ── ACTUALIZAR ────────────────────────────────────────────────────────

        /// <inheritdoc/>
        public void Actualizar(Tarea tarea)
        {
            const string sql = @"
                UPDATE dbo.Tareas
                SET Titulo       = @Titulo,
                    Descripcion  = @Descripcion,
                    FechaEntrega = @FechaEntrega,
                    HoraEntrega  = @HoraEntrega,
                    Prioridad    = @Prioridad,
                    Completada   = @Completada
                WHERE IdTarea = @IdTarea;";

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(new SqlParameter("@IdTarea", System.Data.SqlDbType.Int) { Value = tarea.IdTarea });
            AgregarParametrosTarea(cmd, tarea);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ── ELIMINAR ──────────────────────────────────────────────────────────

        /// <inheritdoc/>
        public void Eliminar(int idTarea)
        {
            const string sql = "DELETE FROM dbo.Tareas WHERE IdTarea = @IdTarea;";

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(new SqlParameter("@IdTarea", System.Data.SqlDbType.Int) { Value = idTarea });

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ── AUXILIARES PRIVADOS ───────────────────────────────────────────────

        /// <summary>
        /// Añade al comando los parámetros de datos de la tarea (sin @IdTarea).
        /// Se reutiliza en INSERT y UPDATE para evitar duplicación.
        /// Los tipos SQL se declaran explícitamente para evitar inferencia incorrecta
        /// de <c>AddWithValue</c>.
        /// </summary>
        private static void AgregarParametrosTarea(SqlCommand cmd, Tarea tarea)
        {
            cmd.Parameters.Add(new SqlParameter("@Titulo",       System.Data.SqlDbType.NVarChar, 200)  { Value = tarea.Titulo });
            cmd.Parameters.Add(new SqlParameter("@Descripcion",  System.Data.SqlDbType.NVarChar, 1000) { Value = tarea.Descripcion });
            cmd.Parameters.Add(new SqlParameter("@FechaEntrega", System.Data.SqlDbType.Date)           { Value = tarea.FechaEntrega.Date });
            cmd.Parameters.Add(new SqlParameter("@HoraEntrega",  System.Data.SqlDbType.Time)           { Value = tarea.HoraEntrega });
            cmd.Parameters.Add(new SqlParameter("@Prioridad",    System.Data.SqlDbType.TinyInt)        { Value = (byte)tarea.Prioridad });
            cmd.Parameters.Add(new SqlParameter("@Completada",   System.Data.SqlDbType.Bit)            { Value = tarea.Completada });
        }

        /// <summary>Construye un <see cref="Tarea"/> desde la fila actual del reader.</summary>
        private static Tarea LeerTarea(SqlDataReader reader) => new Tarea
        {
            IdTarea      = reader.GetInt32(ColIdTarea),
            Titulo       = reader.GetString(ColTitulo),
            Descripcion  = reader.GetString(ColDescripcion),
            FechaEntrega = reader.GetDateTime(ColFechaEntrega),
            HoraEntrega  = reader.GetTimeSpan(ColHoraEntrega),
            Prioridad    = (NivelPrioridad)reader.GetByte(ColPrioridad),
            Completada   = reader.GetBoolean(ColCompletada)
        };

        /// <summary>
        /// Vuelca un <see cref="ListaDinamica{T}"/> a un arreglo primitivo.
        /// </summary>
        private static Tarea[] ConvertirAArreglo(ListaDinamica<Tarea> lista)
        {
            Tarea[] resultado = new Tarea[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                resultado[i] = lista[i];
            }
            return resultado;
        }
    }
}
