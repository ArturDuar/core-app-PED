using Core_V1_NET8.Models;
using Core_V1_NET8.Services;
using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    /// <summary>
    /// Modal del historial de tareas completadas.
    /// Cada tarjeta permite abrir el detalle completo (con opción de desmarcar)
    /// mediante <see cref="DetalleTareaForm"/>.
    /// El layout se define en <see cref="FormHistorial.Designer.cs"/>.
    /// </summary>
    public sealed partial class FormHistorial : MaterialSkin.Controls.MaterialForm
    {
        private readonly GestorTareas gestor;

        public FormHistorial(Tarea[] completadas, GestorTareas gestor)
        {
            this.gestor = gestor;

            // 1. Crear controles (Designer)
            InitializeComponent();

            // 2. Ajustes de formulario            // 2. Ajustes de formulario
            Sizable = false;

            // 4. Cargar tarjetas de tareas completadas
            CargarCompletadas(completadas);
        }

        private void CargarCompletadas(Tarea[] completadas)
        {
            flpCompletadas.SuspendLayout();

            for (int i = 0; i < completadas.Length; i++)
            {
                Tarea t = completadas[i];
                flpCompletadas.Controls.Add(CrearTarjetaCompletada(t));
            }

            flpCompletadas.ResumeLayout();
        }

        private Panel CrearTarjetaCompletada(Tarea t)
        {
            Panel tarjeta = new Panel
            {
                Size      = new Size(300, 98),
                BackColor = Color.FromArgb(36, 36, 36),
                Margin    = new Padding(8)
            };

            Panel barra = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 4,
                BackColor = Color.FromArgb(76, 175, 80)
            };

            MaterialLabel lblTituloC = new MaterialLabel
            {
                Text         = t.Titulo,
                Font         = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor    = Color.FromArgb(200, 200, 200),
                Location     = new Point(10, 14),
                Size         = new Size(280, 24),
                AutoEllipsis = true
            };

            MaterialLabel lblFecha = new MaterialLabel
            {
                Text      = $"📅  {t.FechaEntrega:dd MMM yyyy}",
                Font      = new Font("Segoe UI", 8f),
                ForeColor = Color.FromArgb(130, 130, 130),
                Location  = new Point(10, 42),
                AutoSize  = true
            };

            // "Ver detalle" abre DetalleTareaForm en modo completada
            MaterialButton btnDetalle = new MaterialButton
            {
                Text           = "VER DETALLE",
                Type           = MaterialButton.MaterialButtonType.Text,
                UseAccentColor = true,
                Size           = new Size(120, 28),
                Location       = new Point(10, 64)
            };
            btnDetalle.Click += (_, _) =>
            {
                using DetalleTareaForm detalle = new DetalleTareaForm(t, gestor, esPendiente: false);
                if (detalle.ShowDialog(this) == DialogResult.OK)
                {
                    tarjeta.Parent?.Controls.Remove(tarjeta);
                    tarjeta.Dispose();
                    DialogResult = DialogResult.OK;
                }
            };

            tarjeta.Controls.Add(lblTituloC);
            tarjeta.Controls.Add(lblFecha);
            tarjeta.Controls.Add(btnDetalle);
            tarjeta.Controls.Add(barra);   // ← último = primer plano, Dock=Top visible

            return tarjeta;
        }
    }
}
