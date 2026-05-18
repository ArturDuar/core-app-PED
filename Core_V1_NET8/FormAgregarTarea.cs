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

            TareaNueva = new Tarea
            {
                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                FechaEntrega = dtpFechaEntrega.Value.Date,
                Prioridad = prioridadSeleccionada
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCerrarNuevaTarea_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
