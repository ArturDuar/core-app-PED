using Core_V1_NET8.Models;
using Core_V1_NET8.Services;

namespace Core_V1_NET8.UI
{
    /// <summary>
    /// Modal de detalle completo de una tarea.
    /// Permite editar y cambiar estado (pendiente ↔ completada).
    /// Devuelve <see cref="DialogResult.OK"/> si se realizó alguna modificación
    /// que requiera refrescar la UI del formulario padre.
    /// El layout se define en <see cref="DetalleTareaForm.Designer.cs"/>.
    /// </summary>
    public sealed partial class DetalleTareaForm : MaterialSkin.Controls.MaterialForm
    {
        // ── DEPENDENCIAS ──────────────────────────────────────────────────────
        private readonly GestorTareas gestor;
        private Tarea                 tarea;
        private readonly bool         esPendiente;

        // ── CONSTRUCTOR ───────────────────────────────────────────────────────

        /// <param name="tarea">Tarea a mostrar.</param>
        /// <param name="gestor">Gestor de tareas para ejecutar acciones.</param>
        /// <param name="esPendiente">
        ///   <c>true</c> si la tarea está en el MinHeap (pendiente).
        ///   <c>false</c> si viene del historial de completadas.
        /// </param>
        public DetalleTareaForm(Tarea tarea, GestorTareas gestor, bool esPendiente = true)
        {
            this.tarea       = tarea;
            this.gestor      = gestor;
            this.esPendiente = esPendiente;

            // 1. Crear controles (Designer)
            InitializeComponent();

            // 2. Ajustes de layout dependientes del estado de la tarea
            Sizable = false;

            pnlBarra.BackColor          = ColorPrioridad(tarea.Prioridad);
            lblPrioridadBadge.Text      = tarea.Prioridad.ToString().ToUpperInvariant();
            lblPrioridadBadge.ForeColor = ColorPrioridad(tarea.Prioridad);
            txtTitulo.Text              = tarea.Titulo;
            lblFechaHora.Text           = $"📅  {tarea.FechaEntrega:dd MMM yyyy}   🕐  {tarea.HoraEntrega:hh\\:mm}";
            txtDescripcion.Text         = string.IsNullOrWhiteSpace(tarea.Descripcion)
                                            ? "(sin descripción)"
                                            : tarea.Descripcion;

            btnEditar.Visible  = esPendiente;
            btnEstado.Text     = esPendiente ? "✔  MARCAR COMPLETADA" : "↩  DESMARCAR";
            btnEstado.Location = new Point(esPendiente ? 180 : 24, 364);
            btnEstado.Size     = new Size(esPendiente ? 200 : 180, 36);

            // 4. Suscribir eventos
            btnEditar.Click += OnEditar;
            btnEstado.Click += OnCambiarEstado;
        }

        // ── EDITAR ────────────────────────────────────────────────────────────

        private void OnEditar(object? sender, EventArgs e)
        {
            using FormularioTarea modal = new FormularioTarea(tarea);

            if (modal.ShowDialog(this) == DialogResult.OK && modal.TareaResultante is Tarea editada)
            {
                try
                {
                    string tituloAnterior = tarea.Titulo;
                    gestor.EditarTarea(editada, tituloAnterior);

                    // Refrescar la vista local con los datos nuevos
                    tarea = editada;
                    RefrescarVistaLocal();

                    DialogResult = DialogResult.OK;  // indicar al padre que hay cambios
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al editar:\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── CAMBIAR ESTADO ────────────────────────────────────────────────────

        private void OnCambiarEstado(object? sender, EventArgs e)
        {
            try
            {
                if (esPendiente)
                    gestor.MarcarComoCompletada(tarea.IdTarea);
                else
                    gestor.DesmarcarCompletada(tarea.IdTarea);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── REFRESCO INTERNO ──────────────────────────────────────────────────

        private void RefrescarVistaLocal()
        {
            txtTitulo.Text              = tarea.Titulo;
            lblFechaHora.Text           = $"📅  {tarea.FechaEntrega:dd MMM yyyy}   🕐  {tarea.HoraEntrega:hh\\:mm}";
            lblPrioridadBadge.Text      = tarea.Prioridad.ToString().ToUpperInvariant();
            lblPrioridadBadge.ForeColor = ColorPrioridad(tarea.Prioridad);
            pnlBarra.BackColor          = ColorPrioridad(tarea.Prioridad);
            txtDescripcion.Text         = string.IsNullOrWhiteSpace(tarea.Descripcion)
                                            ? "(sin descripción)"
                                            : tarea.Descripcion;
        }

        // ── AUXILIAR ──────────────────────────────────────────────────────────

        private static Color ColorPrioridad(NivelPrioridad p) => p switch
        {
            NivelPrioridad.Urgente    => Color.FromArgb(207, 102, 121),
            NivelPrioridad.Importante => Color.FromArgb(230, 145, 56),
            _                         => Color.FromArgb(76, 175, 80)
        };
    }
}
