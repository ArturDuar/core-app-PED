namespace Core_V1_NET8
{
    partial class Form1
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
            panel1 = new Panel();
            CORE = new Label();
            panel2 = new Panel();
            flpMisTareas = new FlowLayoutPanel();
            button2 = new Button();
            btnAgregarTarea = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(17, 20, 26);
            panel1.Controls.Add(CORE);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1048, 83);
            panel1.TabIndex = 0;
            // 
            // CORE
            // 
            CORE.AutoSize = true;
            CORE.Font = new Font("Microsoft Sans Serif", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CORE.ForeColor = Color.MediumTurquoise;
            CORE.Location = new Point(12, 18);
            CORE.Name = "CORE";
            CORE.Size = new Size(110, 51);
            CORE.TabIndex = 0;
            CORE.Text = "core";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            panel2.Controls.Add(flpMisTareas);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(btnAgregarTarea);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(1048, 510);
            panel2.TabIndex = 1;
            // 
            // flpMisTareas
            // 
            flpMisTareas.BackColor = Color.FromArgb(64, 64, 64);
            flpMisTareas.Location = new Point(612, 113);
            flpMisTareas.Name = "flpMisTareas";
            flpMisTareas.Size = new Size(407, 352);
            flpMisTareas.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSeaGreen;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(756, 75);
            button2.Name = "button2";
            button2.Size = new Size(124, 28);
            button2.TabIndex = 5;
            button2.Text = "Ver historial";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnAgregarTarea
            // 
            btnAgregarTarea.BackColor = Color.LightSeaGreen;
            btnAgregarTarea.BackgroundImageLayout = ImageLayout.None;
            btnAgregarTarea.FlatStyle = FlatStyle.Flat;
            btnAgregarTarea.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarTarea.Location = new Point(612, 75);
            btnAgregarTarea.Name = "btnAgregarTarea";
            btnAgregarTarea.Size = new Size(124, 28);
            btnAgregarTarea.TabIndex = 4;
            btnAgregarTarea.Text = "+ Agregar tarea";
            btnAgregarTarea.UseVisualStyleBackColor = false;
            btnAgregarTarea.Click += btnAgregarTarea_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Silver;
            textBox1.Location = new Point(614, 42);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Buscar tareas...";
            textBox1.Size = new Size(407, 19);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(608, 12);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 2;
            label2.Text = "Mis tareas";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Location = new Point(35, 113);
            panel3.Name = "panel3";
            panel3.Size = new Size(514, 352);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(140, 75);
            label1.Name = "label1";
            label1.Size = new Size(319, 26);
            label1.TabIndex = 0;
            label1.Text = "Tarea mas urgente actualmente";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 593);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CORE;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flpMisTareas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAgregarTarea;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}
