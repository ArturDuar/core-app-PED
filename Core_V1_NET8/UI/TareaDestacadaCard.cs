using Core_V1_NET8.Models;

namespace Core_V1_NET8.UI
{
    /// <summary>
    /// Tarjeta visual de la tarea más urgente del dashboard.
    /// Sigue el mismo patrón que <see cref="TareaCard"/>: layout en Designer.cs
    /// y lógica de presentación aquí.
    /// </summary>
    public sealed partial class TareaDestacadaCard : UserControl
    {
        // ── CONSTANTES DE DISEÑO ──────────────────────────────────────────────
        public const int CARD_WIDTH  = 460;
        public const int CARD_HEIGHT = 520;

        private static readonly Color CardBackground  = Color.FromArgb(36, 36, 36);
        private static readonly Color ColorUrgente    = Color.FromArgb(207, 102, 121);
        private static readonly Color ColorImportante = Color.FromArgb(230, 145, 56);
        private static readonly Color ColorNormal     = Color.FromArgb(76, 175, 80);
        private static readonly Color ColorVacio      = Color.FromArgb(70, 70, 70);

        // ── EVENTOS ───────────────────────────────────────────────────────────
        /// <summary>Se dispara cuando el usuario pulsa "Marcar como completada".</summary>
        public event EventHandler? CompletarSolicitado;

        // ── CONSTRUCTOR ───────────────────────────────────────────────────────
        public TareaDestacadaCard()
        {
            InitializeComponent();
            btnCompletar.Click += (_, _) => CompletarSolicitado?.Invoke(this, EventArgs.Empty);
            MostrarVacio();
        }

        // ── API PÚBLICA ───────────────────────────────────────────────────────

        /// <summary>Actualiza la tarjeta con los datos de la tarea más urgente.</summary>
        public void MostrarTarea(Tarea tarea)
        {
            Color color = ObtenerColor(tarea.Prioridad);

            pnlBarra.BackColor  = color;
            lblBadge.BackColor  = color;
            lblBadge.Text       = tarea.Prioridad.ToString().ToUpperInvariant();
            lblHeader.ForeColor = color;

            lblTitulo.Text  = tarea.Titulo;
            lblDetalle.Text = string.IsNullOrWhiteSpace(tarea.Descripcion)
                ? "(sin descripción)"
                : tarea.Descripcion;

            lblFecha.Text = $"📅  {tarea.FechaEntrega:dd/MM/yyyy}";
            lblHora.Text  = tarea.HoraEntrega == TimeSpan.Zero
                ? "⏰  (opcional)"
                : $"⏰  {tarea.HoraEntrega:hh\\:mm}";

            lblRegistro.Text = $"🗓  Entrega: {tarea.FechaEntrega:dd/MM/yyyy}  {tarea.HoraEntrega:hh\\:mm}";

            pnlSep2.Visible      = true;
            pnlDivider.Visible   = true;
            btnCompletar.Visible = true;
        }

        /// <summary>Muestra el estado vacío (sin tareas pendientes).</summary>
        public void MostrarVacio()
        {
            pnlBarra.BackColor  = ColorVacio;
            lblBadge.BackColor  = ColorVacio;
            lblBadge.Text       = "SIN TAREAS";
            lblHeader.ForeColor = ColorVacio;

            lblTitulo.Text  = "No hay tareas pendientes";
            lblDetalle.Text = "Agrega una tarea para empezar.";
            lblFecha.Text   = "";
            lblHora.Text    = "";
            lblRegistro.Text = "";

            pnlSep2.Visible      = false;
            pnlDivider.Visible   = false;
            btnCompletar.Visible = false;
        }

        // ── OVERRIDE PAINT ────────────────────────────────────────────────────
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Ignoramos lo que MaterialSkin quiera pintar y forzamos nuestro fondo.
            e.Graphics.Clear(CardBackground);
        }

        // ── AUXILIAR ─────────────────────────────────────────────────────────
        private static Color ObtenerColor(NivelPrioridad p) => p switch
        {
            NivelPrioridad.Urgente    => ColorUrgente,
            NivelPrioridad.Importante => ColorImportante,
            _                         => ColorNormal
        };
    }
}
