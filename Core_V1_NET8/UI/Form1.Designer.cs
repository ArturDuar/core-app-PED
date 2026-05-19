using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlDestacada = new Panel();
            lblDestacadaHeader = new Label();
            pnlDestacadaBadge = new Panel();
            lblDestacadaBadge = new Label();
            pnlDestacadaSep1 = new Panel();
            lblDestacadaTitulo = new Label();
            lblDestacadaDetalle = new Label();
            pnlDestacadaSep2 = new Panel();
            lblDestacadaFecha = new Label();
            lblDestacadaHora = new Label();
            lblDestacadaRegistro = new Label();
            pnlDestacadaDivider = new Panel();
            btnMarcarCompletada = new MaterialButton();
            pnlDestacadaBarra = new Panel();
            pnlDerecha = new Panel();
            lblMisTareas = new MaterialLabel();
            txtBuscar = new MaterialTextBox2();
            btnAgregarTarea = new MaterialButton();
            btnVerHistorial = new MaterialButton();
            flpMisTareas = new FlowLayoutPanel();
            pnlDestacada.SuspendLayout();
            pnlDestacadaBadge.SuspendLayout();
            pnlDerecha.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDestacada
            // 
            pnlDestacada.BackColor = Color.FromArgb(28, 38, 48);
            pnlDestacada.Controls.Add(lblDestacadaHeader);
            pnlDestacada.Controls.Add(pnlDestacadaBadge);
            pnlDestacada.Controls.Add(pnlDestacadaSep1);
            pnlDestacada.Controls.Add(lblDestacadaTitulo);
            pnlDestacada.Controls.Add(lblDestacadaDetalle);
            pnlDestacada.Controls.Add(pnlDestacadaSep2);
            pnlDestacada.Controls.Add(lblDestacadaFecha);
            pnlDestacada.Controls.Add(lblDestacadaHora);
            pnlDestacada.Controls.Add(lblDestacadaRegistro);
            pnlDestacada.Controls.Add(pnlDestacadaDivider);
            pnlDestacada.Controls.Add(btnMarcarCompletada);
            pnlDestacada.Controls.Add(pnlDestacadaBarra);
            pnlDestacada.Location = new Point(20, 80);
            pnlDestacada.Name = "pnlDestacada";
            pnlDestacada.Size = new Size(460, 520);
            pnlDestacada.TabIndex = 0;
            // 
            // lblDestacadaHeader
            // 
            lblDestacadaHeader.AutoSize = true;
            lblDestacadaHeader.BackColor = Color.Transparent;
            lblDestacadaHeader.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDestacadaHeader.ForeColor = Color.FromArgb(207, 102, 121);
            lblDestacadaHeader.Location = new Point(20, 18);
            lblDestacadaHeader.Name = "lblDestacadaHeader";
            lblDestacadaHeader.Size = new Size(122, 13);
            lblDestacadaHeader.TabIndex = 0;
            lblDestacadaHeader.Text = "TAREA MAS URGENTE";
            // 
            // pnlDestacadaBadge
            // 
            pnlDestacadaBadge.BackColor = Color.FromArgb(207, 102, 121);
            pnlDestacadaBadge.Controls.Add(lblDestacadaBadge);
            pnlDestacadaBadge.Location = new Point(290, 12);
            pnlDestacadaBadge.Name = "pnlDestacadaBadge";
            pnlDestacadaBadge.Size = new Size(140, 22);
            pnlDestacadaBadge.TabIndex = 1;
            // 
            // lblDestacadaBadge
            // 
            lblDestacadaBadge.AutoSize = true;
            lblDestacadaBadge.BackColor = Color.Transparent;
            lblDestacadaBadge.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblDestacadaBadge.ForeColor = Color.White;
            lblDestacadaBadge.Location = new Point(8, 4);
            lblDestacadaBadge.Name = "lblDestacadaBadge";
            lblDestacadaBadge.Size = new Size(50, 12);
            lblDestacadaBadge.TabIndex = 0;
            lblDestacadaBadge.Text = "URGENTE";
            // 
            // pnlDestacadaSep1
            // 
            pnlDestacadaSep1.BackColor = Color.FromArgb(50, 65, 80);
            pnlDestacadaSep1.Location = new Point(20, 46);
            pnlDestacadaSep1.Name = "pnlDestacadaSep1";
            pnlDestacadaSep1.Size = new Size(420, 1);
            pnlDestacadaSep1.TabIndex = 2;
            // 
            // lblDestacadaTitulo
            // 
            lblDestacadaTitulo.BackColor = Color.Transparent;
            lblDestacadaTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDestacadaTitulo.ForeColor = Color.FromArgb(245, 245, 245);
            lblDestacadaTitulo.Location = new Point(18, 56);
            lblDestacadaTitulo.Name = "lblDestacadaTitulo";
            lblDestacadaTitulo.Size = new Size(424, 100);
            lblDestacadaTitulo.TabIndex = 3;
            lblDestacadaTitulo.Text = "---";
            // 
            // lblDestacadaDetalle
            // 
            lblDestacadaDetalle.BackColor = Color.Transparent;
            lblDestacadaDetalle.Font = new Font("Segoe UI", 9.5F);
            lblDestacadaDetalle.ForeColor = Color.FromArgb(160, 160, 160);
            lblDestacadaDetalle.Location = new Point(18, 162);
            lblDestacadaDetalle.Name = "lblDestacadaDetalle";
            lblDestacadaDetalle.Size = new Size(424, 110);
            lblDestacadaDetalle.TabIndex = 4;
            // 
            // pnlDestacadaSep2
            // 
            pnlDestacadaSep2.BackColor = Color.FromArgb(50, 65, 80);
            pnlDestacadaSep2.Location = new Point(20, 280);
            pnlDestacadaSep2.Name = "pnlDestacadaSep2";
            pnlDestacadaSep2.Size = new Size(420, 1);
            pnlDestacadaSep2.TabIndex = 5;
            // 
            // lblDestacadaFecha
            // 
            lblDestacadaFecha.AutoSize = true;
            lblDestacadaFecha.BackColor = Color.Transparent;
            lblDestacadaFecha.Font = new Font("Segoe UI", 9F);
            lblDestacadaFecha.ForeColor = Color.FromArgb(140, 140, 140);
            lblDestacadaFecha.Location = new Point(20, 292);
            lblDestacadaFecha.Name = "lblDestacadaFecha";
            lblDestacadaFecha.Size = new Size(182, 15);
            lblDestacadaFecha.TabIndex = 6;
            lblDestacadaFecha.Text = "Fecha de entrega:  DD/MM/YYYY";
            // 
            // lblDestacadaHora
            // 
            lblDestacadaHora.AutoSize = true;
            lblDestacadaHora.BackColor = Color.Transparent;
            lblDestacadaHora.Font = new Font("Segoe UI", 9F);
            lblDestacadaHora.ForeColor = Color.FromArgb(140, 140, 140);
            lblDestacadaHora.Location = new Point(240, 292);
            lblDestacadaHora.Name = "lblDestacadaHora";
            lblDestacadaHora.Size = new Size(69, 15);
            lblDestacadaHora.TabIndex = 7;
            lblDestacadaHora.Text = "Hora:  00:00";
            // 
            // lblDestacadaRegistro
            // 
            lblDestacadaRegistro.AutoSize = true;
            lblDestacadaRegistro.BackColor = Color.Transparent;
            lblDestacadaRegistro.Font = new Font("Segoe UI", 7.5F);
            lblDestacadaRegistro.ForeColor = Color.FromArgb(90, 90, 90);
            lblDestacadaRegistro.Location = new Point(20, 322);
            lblDestacadaRegistro.Name = "lblDestacadaRegistro";
            lblDestacadaRegistro.Size = new Size(0, 12);
            lblDestacadaRegistro.TabIndex = 8;
            // 
            // pnlDestacadaDivider
            // 
            pnlDestacadaDivider.BackColor = Color.FromArgb(50, 65, 80);
            pnlDestacadaDivider.Location = new Point(0, 350);
            pnlDestacadaDivider.Name = "pnlDestacadaDivider";
            pnlDestacadaDivider.Size = new Size(460, 1);
            pnlDestacadaDivider.TabIndex = 9;
            // btnMarcarCompletada
            btnMarcarCompletada.Name           = "btnMarcarCompletada";
            btnMarcarCompletada.Text           = "✓  MARCAR COMO COMPLETADA";
            btnMarcarCompletada.Type           = MaterialButton.MaterialButtonType.Contained;
            btnMarcarCompletada.UseAccentColor = true;
            btnMarcarCompletada.HighEmphasis   = true;
            btnMarcarCompletada.Location       = new Point(20, 362);
            btnMarcarCompletada.Size           = new Size(420, 40);
            btnMarcarCompletada.TabIndex       = 10;
            btnMarcarCompletada.Click         += btnMarcarCompletada_Click;
            // 
            // pnlDestacadaBarra
            // 
            pnlDestacadaBarra.BackColor = Color.FromArgb(207, 102, 121);
            pnlDestacadaBarra.Dock = DockStyle.Top;
            pnlDestacadaBarra.Location = new Point(0, 0);
            pnlDestacadaBarra.Name = "pnlDestacadaBarra";
            pnlDestacadaBarra.Size = new Size(460, 6);
            pnlDestacadaBarra.TabIndex = 11;
            // 
            // pnlDerecha
            // 
            pnlDerecha.BackColor = Color.Transparent;
            pnlDerecha.Controls.Add(lblMisTareas);
            pnlDerecha.Controls.Add(txtBuscar);
            pnlDerecha.Controls.Add(btnAgregarTarea);
            pnlDerecha.Controls.Add(btnVerHistorial);
            pnlDerecha.Controls.Add(flpMisTareas);
            pnlDerecha.Location = new Point(504, 80);
            pnlDerecha.Name = "pnlDerecha";
            pnlDerecha.Size = new Size(700, 520);
            pnlDerecha.TabIndex = 1;
            // 
            // lblMisTareas
            // 
            lblMisTareas.AutoSize = true;
            lblMisTareas.Depth = 0;
            lblMisTareas.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMisTareas.ForeColor = Color.FromArgb(240, 240, 240);
            lblMisTareas.Location = new Point(0, 0);
            lblMisTareas.MouseState = MaterialSkin.MouseState.HOVER;
            lblMisTareas.Name = "lblMisTareas";
            lblMisTareas.Size = new Size(75, 19);
            lblMisTareas.TabIndex = 0;
            lblMisTareas.Text = "Mis tareas";
            // 
            // txtBuscar
            // 
            txtBuscar.AnimateReadOnly = false;
            txtBuscar.BackgroundImageLayout = ImageLayout.None;
            txtBuscar.CharacterCasing = CharacterCasing.Normal;
            txtBuscar.Depth = 0;
            txtBuscar.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscar.HideSelection = true;
            txtBuscar.Hint = "Buscar por prefijo de titulo...";
            txtBuscar.LeadingIcon = null;
            txtBuscar.Location = new Point(0, 36);
            txtBuscar.MaxLength = 32767;
            txtBuscar.MouseState = MaterialSkin.MouseState.OUT;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PasswordChar = '\0';
            txtBuscar.PrefixSuffixText = null;
            txtBuscar.ReadOnly = false;
            txtBuscar.RightToLeft = RightToLeft.No;
            txtBuscar.SelectedText = "";
            txtBuscar.SelectionLength = 0;
            txtBuscar.SelectionStart = 0;
            txtBuscar.ShortcutsEnabled = true;
            txtBuscar.Size = new Size(688, 48);
            txtBuscar.TabIndex = 0;
            txtBuscar.TabStop = false;
            txtBuscar.TextAlign = HorizontalAlignment.Left;
            txtBuscar.TrailingIcon = null;
            txtBuscar.UseSystemPasswordChar = false;
            // btnAgregarTarea
            btnAgregarTarea.Name           = "btnAgregarTarea";
            btnAgregarTarea.Text           = "+ AGREGAR TAREA";
            btnAgregarTarea.Type           = MaterialButton.MaterialButtonType.Contained;
            btnAgregarTarea.UseAccentColor = true;
            btnAgregarTarea.HighEmphasis   = true;
            btnAgregarTarea.Location       = new Point(0, 96);
            btnAgregarTarea.Size           = new Size(168, 36);
            btnAgregarTarea.TabIndex       = 1;
            btnAgregarTarea.Click         += btnAgregarTarea_Click;
            // 
            // btnVerHistorial
            // 
            btnVerHistorial.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVerHistorial.Density = MaterialButton.MaterialButtonDensity.Default;
            btnVerHistorial.Depth = 0;
            btnVerHistorial.HighEmphasis = true;
            btnVerHistorial.Icon = null;
            btnVerHistorial.Location = new Point(180, 96);
            btnVerHistorial.Margin = new Padding(4, 6, 4, 6);
            btnVerHistorial.MouseState = MaterialSkin.MouseState.HOVER;
            btnVerHistorial.Name = "btnVerHistorial";
            btnVerHistorial.NoAccentTextColor = Color.Empty;
            btnVerHistorial.Size = new Size(126, 36);
            btnVerHistorial.TabIndex = 2;
            btnVerHistorial.Text = "VER HISTORIAL";
            btnVerHistorial.Type = MaterialButton.MaterialButtonType.Outlined;
            btnVerHistorial.UseAccentColor = false;
            btnVerHistorial.Click += btnVerHistorial_Click;
            // 
            // flpMisTareas
            // 
            flpMisTareas.AutoScroll = true;
            flpMisTareas.BackColor = Color.Transparent;
            flpMisTareas.Location = new Point(0, 144);
            flpMisTareas.Name = "flpMisTareas";
            flpMisTareas.Size = new Size(688, 364);
            flpMisTareas.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 640);
            Controls.Add(pnlDestacada);
            Controls.Add(pnlDerecha);
            Name = "Form1";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Core";
            pnlDestacada.ResumeLayout(false);
            pnlDestacada.PerformLayout();
            pnlDestacadaBadge.ResumeLayout(false);
            pnlDestacadaBadge.PerformLayout();
            pnlDerecha.ResumeLayout(false);
            pnlDerecha.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel            pnlDestacada;
        private Panel            pnlDestacadaBarra;
        private Label            lblDestacadaHeader;
        private Panel            pnlDestacadaBadge;
        private Label            lblDestacadaBadge;
        private Panel            pnlDestacadaSep1;
        private Label            lblDestacadaTitulo;
        private Label            lblDestacadaDetalle;
        private Panel            pnlDestacadaSep2;
        private Label            lblDestacadaFecha;
        private Label            lblDestacadaHora;
        private Label            lblDestacadaRegistro;
        private Panel            pnlDestacadaDivider;
        private MaterialButton   btnMarcarCompletada;
        private Panel            pnlDerecha;
        private MaterialLabel    lblMisTareas;
        private MaterialTextBox2 txtBuscar;
        private MaterialButton   btnAgregarTarea;
        private MaterialButton   btnVerHistorial;
        private FlowLayoutPanel  flpMisTareas;
    }
}
