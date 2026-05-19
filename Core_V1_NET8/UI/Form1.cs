using Core_V1_NET8.Data.Repositories;
using Core_V1_NET8.Models;
using Core_V1_NET8.Services;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    /// <summary>
    /// Formulario principal de la aplicación.
    /// Hereda de <see cref="MaterialForm"/> para obtener el chrome de Material Design.
    /// Toda iteración de datos usa exclusivamente arreglos primitivos <c>Tarea[]</c>
    /// provenientes de <see cref="GestorTareas"/>; no se usa List&lt;T&gt; ni LINQ.
    /// </summary>
    public partial class Form1 : MaterialForm
    {
        private readonly GestorTareas gestor;

        // ── CONSTRUCTOR ───────────────────────────────────────────────────────

        public Form1()
        {
            // 1. Generar controles definidos en el Designer
            InitializeComponent();

            // 2. Inicializar MaterialSkin DESPUÉS de InitializeComponent.
            //    AddFormToManage debe recibir el formulario ya construido.
            ConfigurarMaterialSkin();

            // 3. Inicializar la capa de negocio
            gestor = new GestorTareas(new TareaRepository());

            try
            {
                gestor.CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar tareas desde la base de datos:\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 4. Suscribir eventos de UI
            txtBuscar.TextChanged += OnBuscarTextChanged;

            // 5. Renderizado inicial
            ActualizarUI();
        }

        // ── CONFIGURACIÓN MATERIAL SKIN ───────────────────────────────────────

        private void ConfigurarMaterialSkin()
        {
            MaterialSkinManager skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme       = MaterialSkinManager.Themes.DARK;
            skin.ColorScheme = new ColorScheme(
                primary      : Primary.Teal600,
                darkPrimary  : Primary.Teal700,
                lightPrimary : Primary.Teal100,
                accent       : Accent.Teal200,
                textShade    : TextShade.BLACK);
        }

        // ── ACTUALIZACIÓN COMPLETA DE LA UI ──────────────────────────────────

        /// <summary>
        /// Reconstruye el panel de tarjetas y refresca la tarjeta destacada.
        /// Llama a este método después de cualquier operación que cambie el estado.
        /// </summary>
        public void ActualizarUI()
        {
            ActualizarTarjetaDestacada();
            ActualizarPanelTareas();
        }

        // ── TARJETA DESTACADA (panel izquierdo) ───────────────────────────────

        private void ActualizarTarjetaDestacada()
        {
            Tarea? masUrgente = gestor.ObtenerTareaMasUrgente();

            if (masUrgente is null)
            {
                lblDestacadaBadge.Text      = "SIN TAREAS";
                pnlDestacadaBadge.BackColor = Color.FromArgb(70, 70, 70);
                lblDestacadaFecha.Text      = "";
                lblDestacadaHora.Text       = "";
                lblDestacadaTitulo.Text     = "No hay tareas pendientes";
                lblDestacadaDetalle.Text    = "Agrega una tarea para empezar.";
                lblDestacadaRegistro.Text   = "";
                pnlDestacadaBarra.BackColor = Color.FromArgb(70, 70, 70);
                btnMarcarCompletada.Visible = false;
                pnlDestacadaDivider.Visible = false;
                pnlDestacadaSep2.Visible    = false;
                return;
            }

            pnlDestacadaSep2.Visible    = true;
            btnMarcarCompletada.Visible = true;
            pnlDestacadaDivider.Visible = true;

            // Colores por prioridad
            Color colorPrioridad = masUrgente.Prioridad switch
            {
                NivelPrioridad.Urgente    => Color.FromArgb(207, 102, 121),
                NivelPrioridad.Importante => Color.FromArgb(230, 145,  56),
                _                         => Color.FromArgb( 76, 175,  80)
            };

            // Franja superior
            pnlDestacadaBarra.BackColor = colorPrioridad;

            // Badge de prioridad
            pnlDestacadaBadge.BackColor = colorPrioridad;
            lblDestacadaBadge.Text      = masUrgente.Prioridad.ToString();

            // Fecha y hora de entrega
            lblDestacadaFecha.Text = $"📅  {masUrgente.FechaEntrega:dd/MM/yyyy}";
            lblDestacadaHora.Text  = masUrgente.HoraEntrega == TimeSpan.Zero
                ? "⏰  (opcional)"
                : $"⏰  {masUrgente.HoraEntrega:hh\\:mm}";

            // Título y descripción
            lblDestacadaTitulo.Text  = masUrgente.Titulo;
            lblDestacadaDetalle.Text = masUrgente.Descripcion;

            // Pie de tarjeta
            lblDestacadaRegistro.Text = $"🗓  Entrega: {masUrgente.FechaEntrega:dd/MM/yyyy}  {masUrgente.HoraEntrega:hh\\:mm}";
        }

        // ── PANEL DE TARJETAS (panel derecho) ────────────────────────────────

        private void ActualizarPanelTareas()
        {
            // Limpiar tarjetas anteriores liberando sus recursos
            for (int i = flpMisTareas.Controls.Count - 1; i >= 0; i--)
            {
                Control c = flpMisTareas.Controls[i];
                flpMisTareas.Controls.RemoveAt(i);
                c.Dispose();
            }

            Tarea[] pendientes = gestor.ObtenerTareasPendientes();
            Tarea?  masUrgente = gestor.ObtenerTareaMasUrgente();
            int     idUrgente  = masUrgente?.IdTarea ?? -1;

            int anchoCliente = flpMisTareas.ClientSize.Width
                               - SystemInformation.VerticalScrollBarWidth;
            int anchoTarjeta = Math.Max((anchoCliente / 2) - 8, TareaCard.CARD_WIDTH);

            flpMisTareas.SuspendLayout();

            for (int i = 0; i < pendientes.Length; i++)
            {
                Tarea t = pendientes[i];

                TareaCard card = new TareaCard(t, esLaMasUrgente: t.IdTarea == idUrgente);
                card.Width               = anchoTarjeta;
                card.EliminarSolicitado += OnEliminarTarea;
                card.VerMasSolicitado   += OnVerMasTarea;

                flpMisTareas.Controls.Add(card);
            }

            flpMisTareas.ResumeLayout(performLayout: true);
            flpMisTareas.Refresh();   // forzar repintado tras reconstruir tarjetas
        }

        // ── MANEJADORES DE BOTONES PRINCIPALES ───────────────────────────────

        private void btnMarcarCompletada_Click(object? sender, EventArgs e)
        {
            Tarea? masUrgente = gestor.ObtenerTareaMasUrgente();
            if (masUrgente is null) return;

            try
            {
                gestor.MarcarComoCompletada(masUrgente.IdTarea);
                ActualizarUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al completar la tarea:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTarea_Click(object? sender, EventArgs e)
        {
            using FormularioTarea modal = new FormularioTarea();

            if (modal.ShowDialog(this) == DialogResult.OK
                && modal.TareaResultante is Tarea nueva)
            {
                try
                {
                    gestor.AgregarTarea(nueva);
                    ActualizarUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la tarea:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerHistorial_Click(object? sender, EventArgs e)
        {
            Tarea[] completadas = gestor.ObtenerTareasCompletadas();

            using FormHistorial modal = new FormHistorial(completadas, gestor);
            if (modal.ShowDialog(this) == DialogResult.OK)
                ActualizarUI();
        }

        // ── MANEJADORES DE EVENTOS DE TARJETAS ───────────────────────────────

        private void OnEliminarTarea(object? sender, int idTarea)
        {
            try
            {
                gestor.EliminarTarea(idTarea);
                ActualizarUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la tarea:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnVerMasTarea(object? sender, Tarea tarea)
        {
            using DetalleTareaForm modal = new DetalleTareaForm(tarea, gestor, esPendiente: true);
            if (modal.ShowDialog(this) == DialogResult.OK)
                ActualizarUI();
        }

        // ── BÚSQUEDA EN TIEMPO REAL (Trie) ───────────────────────────────────

        private void OnBuscarTextChanged(object? sender, EventArgs e)
        {
            string prefijo = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(prefijo))
            {
                ActualizarPanelTareas();
                return;
            }

            Tarea[] resultados = gestor.Buscar(prefijo);

            for (int i = flpMisTareas.Controls.Count - 1; i >= 0; i--)
            {
                Control c = flpMisTareas.Controls[i];
                flpMisTareas.Controls.RemoveAt(i);
                c.Dispose();
            }

            Tarea? masUrgente = gestor.ObtenerTareaMasUrgente();
            int    idUrgente  = masUrgente?.IdTarea ?? -1;

            flpMisTareas.SuspendLayout();

            for (int i = 0; i < resultados.Length; i++)
            {
                Tarea t        = resultados[i];
                TareaCard card = new TareaCard(t, t.IdTarea == idUrgente);
                card.EliminarSolicitado += OnEliminarTarea;
                card.VerMasSolicitado   += OnVerMasTarea;
                flpMisTareas.Controls.Add(card);
            }

            flpMisTareas.ResumeLayout(performLayout: true);
        }
    }
}