using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class FormularioTarea
    {
        private System.ComponentModel.IContainer? components = null;

        // ── CONTROLES ─────────────────────────────────────────────────────────
        private MaterialTextBox  txtTitulo      = null!;
        private TextBox          txtDescripcion = null!;
        private DateTimePicker   dtpFecha       = null!;
        private MaterialTextBox  txtHora        = null!;
        private MaterialComboBox cmbPrioridad   = null!;
        private MaterialButton   btnGuardar     = null!;
        private MaterialButton   btnCancelar    = null!;
        private MaterialLabel    lblDesc        = null!;
        private MaterialLabel    lblFecha       = null!;
        private MaterialLabel    lblPrioridad   = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTitulo = new MaterialTextBox();
            lblDesc = new MaterialLabel();
            txtDescripcion = new TextBox();
            lblFecha = new MaterialLabel();
            dtpFecha = new DateTimePicker();
            txtHora = new MaterialTextBox();
            lblPrioridad = new MaterialLabel();
            cmbPrioridad = new MaterialComboBox();
            btnGuardar = new MaterialButton();
            btnCancelar = new MaterialButton();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.AnimateReadOnly = false;
            txtTitulo.BorderStyle = BorderStyle.None;
            txtTitulo.Depth = 0;
            txtTitulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTitulo.Hint = "Título de la tarea";
            txtTitulo.LeadingIcon = null;
            txtTitulo.Location = new Point(24, 90);
            txtTitulo.MaxLength = 50;
            txtTitulo.MouseState = MaterialSkin.MouseState.OUT;
            txtTitulo.Multiline = false;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(432, 50);
            txtTitulo.TabIndex = 0;
            txtTitulo.Text = "";
            txtTitulo.TrailingIcon = null;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.BackColor = Color.Transparent;
            lblDesc.Depth = 0;
            lblDesc.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDesc.ForeColor = Color.FromArgb(150, 150, 150);
            lblDesc.Location = new Point(26, 152);
            lblDesc.MouseState = MaterialSkin.MouseState.HOVER;
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(84, 19);
            lblDesc.TabIndex = 1;
            lblDesc.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.FromArgb(48, 48, 48);
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.ForeColor = Color.FromArgb(230, 230, 230);
            txtDescripcion.Location = new Point(24, 172);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(432, 90);
            txtDescripcion.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Depth = 0;
            lblFecha.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFecha.ForeColor = Color.FromArgb(150, 150, 150);
            lblFecha.Location = new Point(26, 278);
            lblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(122, 19);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha de entrega";
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarForeColor = Color.FromArgb(230, 230, 230);
            dtpFecha.CalendarMonthBackground = Color.FromArgb(48, 48, 48);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(24, 298);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 2;
            // 
            // txtHora
            // 
            txtHora.AnimateReadOnly = false;
            txtHora.BorderStyle = BorderStyle.None;
            txtHora.Depth = 0;
            txtHora.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtHora.Hint = "Hora HH:MM";
            txtHora.LeadingIcon = null;
            txtHora.Location = new Point(248, 278);
            txtHora.MaxLength = 50;
            txtHora.MouseState = MaterialSkin.MouseState.OUT;
            txtHora.Multiline = false;
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(208, 50);
            txtHora.TabIndex = 3;
            txtHora.Text = "";
            txtHora.TrailingIcon = null;
            // 
            // lblPrioridad
            // 
            lblPrioridad.AutoSize = true;
            lblPrioridad.BackColor = Color.Transparent;
            lblPrioridad.Depth = 0;
            lblPrioridad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPrioridad.ForeColor = Color.FromArgb(150, 150, 150);
            lblPrioridad.Location = new Point(26, 358);
            lblPrioridad.MouseState = MaterialSkin.MouseState.HOVER;
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(65, 19);
            lblPrioridad.TabIndex = 4;
            lblPrioridad.Text = "Prioridad";
            // 
            // cmbPrioridad
            // 
            cmbPrioridad.AutoResize = false;
            cmbPrioridad.BackColor = Color.FromArgb(255, 255, 255);
            cmbPrioridad.Depth = 0;
            cmbPrioridad.DrawMode = DrawMode.OwnerDrawVariable;
            cmbPrioridad.DropDownHeight = 174;
            cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridad.DropDownWidth = 121;
            cmbPrioridad.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbPrioridad.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbPrioridad.IntegralHeight = false;
            cmbPrioridad.ItemHeight = 43;
            cmbPrioridad.Location = new Point(24, 378);
            cmbPrioridad.MaxDropDownItems = 4;
            cmbPrioridad.MouseState = MaterialSkin.MouseState.OUT;
            cmbPrioridad.Name = "cmbPrioridad";
            cmbPrioridad.Size = new Size(432, 49);
            cmbPrioridad.StartIndex = 0;
            cmbPrioridad.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardar.Density = MaterialButton.MaterialButtonDensity.Default;
            btnGuardar.Depth = 0;
            btnGuardar.HighEmphasis = true;
            btnGuardar.Icon = null;
            btnGuardar.Location = new Point(24, 464);
            btnGuardar.Margin = new Padding(4, 6, 4, 6);
            btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.NoAccentTextColor = Color.Empty;
            btnGuardar.Size = new Size(137, 36);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "AGREGAR TAREA";
            btnGuardar.Type = MaterialButton.MaterialButtonType.Contained;
            btnGuardar.UseAccentColor = true;
            btnGuardar.ForeColor      = Color.FromArgb(20, 20, 20);
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.Location = new Point(256, 464);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(96, 36);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Type = MaterialButton.MaterialButtonType.Outlined;
            btnCancelar.UseAccentColor = false;
            // 
            // FormularioTarea
            // 
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(480, 540);
            Controls.Add(txtTitulo);
            Controls.Add(lblDesc);
            Controls.Add(txtDescripcion);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(txtHora);
            Controls.Add(lblPrioridad);
            Controls.Add(cmbPrioridad);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FormularioTarea";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva tarea";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
