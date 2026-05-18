namespace Core_V1_NET8
{
    partial class FormAgregarTarea
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnGuardarTarea = new Button();
            txtDescripcion = new TextBox();
            label5 = new Label();
            cmbPrioridad = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtHoraEntrega = new MaskedTextBox();
            label2 = new Label();
            dtpFechaEntrega = new DateTimePicker();
            txtTitulo = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardarTarea);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbPrioridad);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtHoraEntrega);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpFechaEntrega);
            groupBox1.Controls.Add(txtTitulo);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 476);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = " Nueva tarea ";
            // 
            // btnGuardarTarea
            // 
            btnGuardarTarea.BackColor = Color.Teal;
            btnGuardarTarea.FlatAppearance.BorderSize = 0;
            btnGuardarTarea.FlatStyle = FlatStyle.Flat;
            btnGuardarTarea.Location = new Point(17, 422);
            btnGuardarTarea.Name = "btnGuardarTarea";
            btnGuardarTarea.Size = new Size(269, 36);
            btnGuardarTarea.TabIndex = 10;
            btnGuardarTarea.Text = "Guardar tarea";
            btnGuardarTarea.UseVisualStyleBackColor = false;
            btnGuardarTarea.Click += btnGuardarTarea_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.FromArgb(64, 64, 64);
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.ForeColor = Color.White;
            txtDescripcion.Location = new Point(17, 292);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(292, 112);
            txtDescripcion.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Tai Le", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 270);
            label5.Name = "label5";
            label5.Size = new Size(90, 19);
            label5.TabIndex = 8;
            label5.Text = "Descripcion";
            // 
            // cmbPrioridad
            // 
            cmbPrioridad.BackColor = Color.FromArgb(64, 64, 64);
            cmbPrioridad.ForeColor = SystemColors.Window;
            cmbPrioridad.FormattingEnabled = true;
            cmbPrioridad.Items.AddRange(new object[] { "Urgente", "Importante", "Normal" });
            cmbPrioridad.Location = new Point(17, 226);
            cmbPrioridad.Name = "cmbPrioridad";
            cmbPrioridad.Size = new Size(292, 26);
            cmbPrioridad.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Tai Le", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 204);
            label4.Name = "label4";
            label4.Size = new Size(73, 19);
            label4.TabIndex = 6;
            label4.Text = "Prioridad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Tai Le", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 147);
            label3.Name = "label3";
            label3.Size = new Size(122, 19);
            label3.TabIndex = 5;
            label3.Text = "Hora de entrega";
            // 
            // txtHoraEntrega
            // 
            txtHoraEntrega.BackColor = Color.FromArgb(64, 64, 64);
            txtHoraEntrega.BorderStyle = BorderStyle.None;
            txtHoraEntrega.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoraEntrega.ForeColor = Color.White;
            txtHoraEntrega.Location = new Point(17, 168);
            txtHoraEntrega.Mask = "00:00";
            txtHoraEntrega.Name = "txtHoraEntrega";
            txtHoraEntrega.Size = new Size(292, 22);
            txtHoraEntrega.TabIndex = 4;
            txtHoraEntrega.ValidatingType = typeof(DateTime);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 87);
            label2.Name = "label2";
            label2.Size = new Size(128, 19);
            label2.TabIndex = 3;
            label2.Text = "Fecha de entrega";
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.CalendarForeColor = Color.FromArgb(64, 64, 64);
            dtpFechaEntrega.CalendarMonthBackground = Color.FromArgb(64, 64, 64);
            dtpFechaEntrega.Location = new Point(17, 108);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new Size(292, 24);
            dtpFechaEntrega.TabIndex = 2;
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.FromArgb(64, 64, 64);
            txtTitulo.BorderStyle = BorderStyle.None;
            txtTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitulo.ForeColor = Color.White;
            txtTitulo.Location = new Point(17, 55);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(292, 22);
            txtTitulo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 35);
            label1.Name = "label1";
            label1.Size = new Size(50, 19);
            label1.TabIndex = 0;
            label1.Text = "Titulo";
            // 
            // FormAgregarTarea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(352, 532);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAgregarTarea";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAgregarTarea";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardarTarea;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtHoraEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label1;
    }
}
