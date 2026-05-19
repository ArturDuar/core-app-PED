using Core_V1_NET8.Models;
using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    /// <summary>
    /// Formulario unificado para agregar y editar tareas.
    /// Constructor vacío → modo agregar.
    /// Constructor con <see cref="Tarea"/> → modo editar.
    /// El layout se define en <see cref="FormularioTarea.Designer.cs"/>.
    /// </summary>
    public sealed partial class FormularioTarea : MaterialForm
    {
        // ── RESULTADO ─────────────────────────────────────────────────────────
        /// <summary>Tarea resultante tras confirmar el formulario.</summary>
        public Tarea? TareaResultante { get; private set; }

        // ── ESTADO INTERNO ────────────────────────────────────────────────────
        private readonly Tarea?  _tareaOriginal;   // null en modo agregar
        private readonly bool    _modoEdicion;

        // ── COLORES DE TEMA ───────────────────────────────────────────────────
        // Solo los que se usan desde la lógica del formulario
        private static readonly Color ColorCampo = Color.FromArgb(48, 48, 48);
        private static readonly Color ColorTexto = Color.FromArgb(230, 230, 230);

        // ── CONSTRUCTOR: MODO AGREGAR ─────────────────────────────────────────
        public FormularioTarea() : this(null) { }

        // ── CONSTRUCTOR: MODO EDITAR ──────────────────────────────────────────
        public FormularioTarea(Tarea? tareaExistente)
        {
            _tareaOriginal = tareaExistente;
            _modoEdicion   = tareaExistente is not null;

            // 1. Crear controles (Designer)
            InitializeComponent();

            // 2. Ajustes dependientes del modo
            Text    = _modoEdicion ? "Editar tarea" : "Nueva tarea";
            Sizable = false;

            btnGuardar.Text = _modoEdicion ? "GUARDAR CAMBIOS" : "AGREGAR TAREA";

            // 4. Poblar combo de prioridades
            cmbPrioridad.Items.Add(NivelPrioridad.Urgente);
            cmbPrioridad.Items.Add(NivelPrioridad.Importante);
            cmbPrioridad.Items.Add(NivelPrioridad.Normal);

            // 5. Suscribir eventos
            btnGuardar.Click  += OnGuardar;
            btnCancelar.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

            // 6. Pre-poblar campos en modo edición
            if (_modoEdicion && _tareaOriginal is not null)
                PrecargarCampos(_tareaOriginal);
            else
                cmbPrioridad.SelectedIndex = 2; // Normal por defecto
        }

        // ── PRE-CARGA ─────────────────────────────────────────────────────────

        private void PrecargarCampos(Tarea t)
        {
            txtTitulo.Text            = t.Titulo;
            txtDescripcion.Text        = t.Descripcion;
            txtFecha.Text             = t.FechaEntrega == default ? "" : t.FechaEntrega.ToString("dd/MM/yyyy");
            txtHora.Text              = t.HoraEntrega.ToString(@"hh\:mm");
            cmbPrioridad.SelectedItem = t.Prioridad;
        }

        // ── VALIDACIÓN Y GUARDADO ─────────────────────────────────────────────

        private void OnGuardar(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPrioridad.SelectedItem is not NivelPrioridad prioridad)
            {
                MessageBox.Show("Selecciona una prioridad.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeSpan.TryParse(txtHora.Text, out TimeSpan hora))
            {
                MessageBox.Show("Formato de hora inválido. Usa HH:MM.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParseExact(txtFecha.Text.Trim(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                MessageBox.Show("Formato de fecha inválido. Usa dd/MM/yyyy.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // En modo edición conservamos el ID y el estado Completada original
            TareaResultante = new Tarea
            {
                IdTarea      = _tareaOriginal?.IdTarea ?? 0,
                Titulo       = txtTitulo.Text.Trim(),
                Descripcion  = txtDescripcion.Text.Trim(),
                FechaEntrega = fecha,
                HoraEntrega  = hora,
                Prioridad    = prioridad,
                Completada   = _tareaOriginal?.Completada ?? false
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
