namespace Core_V1_NET8
{
    public partial class FormAgregarTarea : Form
    {
        public Tarea? TareaNueva { get; private set; }

        public FormAgregarTarea()
        {
            InitializeComponent();
            cmbPrioridad.DataSource = Enum.GetValues(typeof(NivelPrioridad));
        }

        private void btnGuardarTarea_Click(object sender, EventArgs e)
        {
            if (cmbPrioridad.SelectedItem is not NivelPrioridad prioridadSeleccionada)
            {
                return;
            }

            // Intentamos convertir el texto de la máscara (ejemplo. "23:59") a TimeSpan
            TimeSpan horaIngresada = TimeSpan.Zero;
            if (TimeSpan.TryParse(txtHoraEntrega.Text, out TimeSpan horaParseada))
            {
                horaIngresada = horaParseada;
            }

            //  Asignamos todos los valores a la nueva tarea
            TareaNueva = new Tarea
            {
                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                FechaEntrega = dtpFechaEntrega.Value.Date,
                HoraEntrega = horaIngresada, // Por Aqui pasamos la hora ya convertida
                Prioridad = prioridadSeleccionada
            };

            // Guardamos en la base de datos
            try
            {
                RepositorioTareas repo = new RepositorioTareas();
                repo.GuardarTarea(TareaNueva);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCerrarNuevaTarea_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
