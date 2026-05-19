using Core_V1_NET8.Models;

namespace Core_V1_NET8.UI
{
    /// <summary>
    /// Tarjeta visual que representa una <see cref="Tarea"/> en el dashboard.
    /// El layout se define en <see cref="TareaCard.Designer.cs"/>; aquí solo vive
    /// la lógica de presentación y los manejadores de eventos.
    /// </summary>
    public sealed partial class TareaCard : UserControl
    {
        // ── CONSTANTES DE DISEÑO ──────────────────────────────────────────────
        public const int CARD_WIDTH  = 310;
        public const int CARD_HEIGHT = 148;

        private static readonly Color ColorUrgente    = Color.FromArgb(207, 102, 121);
        private static readonly Color ColorImportante = Color.FromArgb(230, 145, 56);
        private static readonly Color ColorNormal     = Color.FromArgb(76, 175, 80);

        // ── DATOS ─────────────────────────────────────────────────────────────
        public Tarea Tarea { get; }

        // ── EVENTOS PARA EL FORMULARIO PADRE ─────────────────────────────────
        /// <summary>Se dispara cuando el usuario confirma la eliminación de esta tarjeta.</summary>
        public event EventHandler<int>?   EliminarSolicitado;

        /// <summary>Se dispara cuando el usuario hace clic en "Ver más".</summary>
        public event EventHandler<Tarea>? VerMasSolicitado;

        // ── CONSTRUCTOR ───────────────────────────────────────────────────────
        public TareaCard(Tarea tarea, bool esLaMasUrgente = false)
        {
            Tarea = tarea;

            // 1. Crear controles declarados en el Designer
            InitializeComponent();

            // 2. Aplicar los datos de la tarea a los controles
            Color colorPrioridad        = ObtenerColorPrioridad(tarea.Prioridad);
            pnlBarra.BackColor          = colorPrioridad;
            lblBadgePrioridad.Text      = tarea.Prioridad.ToString().ToUpperInvariant();
            lblBadgePrioridad.ForeColor = colorPrioridad;
            lblUrgenteBadge.Visible     = esLaMasUrgente;
            lblTitulo.Text              = tarea.Titulo;
            lblFechaHora.Text           = "📅  " +
                $"{tarea.FechaEntrega:dd MMM yyyy}  {tarea.HoraEntrega:hh\\:mm}";

            // 3. Suscribir eventos de los botones
            btnVerMas.Click += (_, _) => VerMasSolicitado?.Invoke(this, Tarea);
            btnBorrar.Click += OnBorrarClick;
        }

        // ── LÓGICA DE BORRADO ─────────────────────────────────────────────────

        private void OnBorrarClick(object? sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                $"¿Eliminar la tarea \"{Tarea.Titulo}\"?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmacion == DialogResult.Yes)
                EliminarSolicitado?.Invoke(this, Tarea.IdTarea);
        }

        // ── AUXILIAR ──────────────────────────────────────────────────────────

        private static Color ObtenerColorPrioridad(NivelPrioridad prioridad) => prioridad switch
        {
            NivelPrioridad.Urgente    => ColorUrgente,
            NivelPrioridad.Importante => ColorImportante,
            _                         => ColorNormal
        };
    }
}
