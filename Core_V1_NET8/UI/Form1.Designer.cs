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
            cardDestacada = new TareaDestacadaCard();
            pnlDerecha = new Panel();
            lblMisTareas = new MaterialLabel();
            txtBuscar = new MaterialTextBox2();
            btnAgregarTarea = new MaterialButton();
            btnVerHistorial = new MaterialButton();
            flpMisTareas = new FlowLayoutPanel();
            pnlDerecha.SuspendLayout();
            SuspendLayout();
            // 
            // cardDestacada
            // 
            cardDestacada.Location = new Point(20, 80);
            cardDestacada.Name     = "cardDestacada";
            cardDestacada.Size     = new Size(TareaDestacadaCard.CARD_WIDTH, TareaDestacadaCard.CARD_HEIGHT);
            cardDestacada.TabIndex = 0;
            cardDestacada.CompletarSolicitado += btnMarcarCompletada_Click;
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
            txtBuscar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
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
            // 
            // btnAgregarTarea
            // 
            btnAgregarTarea.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAgregarTarea.BackColor = Color.MediumSeaGreen;
            btnAgregarTarea.Density = MaterialButton.MaterialButtonDensity.Default;
            btnAgregarTarea.Depth = 0;
            btnAgregarTarea.HighEmphasis = true;
            btnAgregarTarea.Icon = null;
            btnAgregarTarea.Location = new Point(0, 96);
            btnAgregarTarea.Margin = new Padding(4, 6, 4, 6);
            btnAgregarTarea.MouseState = MaterialSkin.MouseState.HOVER;
            btnAgregarTarea.Name = "btnAgregarTarea";
            btnAgregarTarea.NoAccentTextColor = Color.Empty;
            btnAgregarTarea.Size = new Size(141, 36);
            btnAgregarTarea.TabIndex = 1;
            btnAgregarTarea.Text = "+ Agregar Tarea";
            btnAgregarTarea.Type = MaterialButton.MaterialButtonType.Contained;
            btnAgregarTarea.UseAccentColor = true;
            btnAgregarTarea.UseVisualStyleBackColor = false;
            btnAgregarTarea.Click += btnAgregarTarea_Click;
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
            Controls.Add(cardDestacada);
            Controls.Add(pnlDerecha);
            Name = "Form1";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Core";
            pnlDerecha.ResumeLayout(false);
            pnlDerecha.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TareaDestacadaCard  cardDestacada;
        private Panel            pnlDerecha;
        private MaterialLabel    lblMisTareas;
        private MaterialTextBox2 txtBuscar;
        private MaterialButton   btnAgregarTarea;
        private MaterialButton   btnVerHistorial;
        private FlowLayoutPanel  flpMisTareas;
    }
}
