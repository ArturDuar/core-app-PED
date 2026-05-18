namespace Core_V1_NET8
{
    public partial class Form1 : Form
    {
        private ColaPrioridadTareas colaTareas;

        public Form1()
        {
            InitializeComponent();
            colaTareas = new ColaPrioridadTareas();
        }

        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {
            FormAgregarTarea formAgregar = new FormAgregarTarea();

            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                Tarea? nueva = formAgregar.TareaNueva;
                if (nueva is null)
                {
                    return;
                }

                colaTareas.Encolar(nueva);
                ActualizarDashboard();
            }
        }

        private void ActualizarDashboard()
        {
            Tarea? masUrgente = colaTareas.ObtenerMasUrgente();
            if (masUrgente != null)
            {
            }

            flpMisTareas.Controls.Clear();

            ListaDinamica<Tarea> todasLasTareas = colaTareas.ObtenerTodas();

            for (int i = 0; i < todasLasTareas.Count; i++)
            {
                Tarea tarea = todasLasTareas[i];
                Panel nuevaTarjeta = CrearTarjetaTarea(tarea);
                flpMisTareas.Controls.Add(nuevaTarjeta);
            }
        }

        private Panel CrearTarjetaTarea(Tarea tarea)
        {
            Panel tarjeta = new Panel();
            tarjeta.Size = new Size(280, 100);
            tarjeta.BackColor = Color.FromArgb(45, 45, 45);
            tarjeta.Margin = new Padding(5);

            Label lblPrioridad = new Label();
            lblPrioridad.Text = tarea.Prioridad.ToString();
            lblPrioridad.Location = new Point(10, 10);
            lblPrioridad.AutoSize = true;
            lblPrioridad.ForeColor = Color.White;

            if (tarea.Prioridad == NivelPrioridad.Urgente)
                lblPrioridad.BackColor = Color.Tomato;
            else if (tarea.Prioridad == NivelPrioridad.Importante)
                lblPrioridad.BackColor = Color.DarkOrange;
            else
                lblPrioridad.BackColor = Color.MediumSeaGreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = tarea.Titulo;
            lblTitulo.Location = new Point(10, 40);
            lblTitulo.AutoSize = true;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha de entrega: " + tarea.FechaEntrega.ToShortDateString();
            lblFecha.Location = new Point(10, 70);
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = Color.DarkGray;
            lblFecha.Font = new Font("Segoe UI", 8);

            tarjeta.Controls.Add(lblPrioridad);
            tarjeta.Controls.Add(lblTitulo);
            tarjeta.Controls.Add(lblFecha);

            return tarjeta;
        }
    }
}
