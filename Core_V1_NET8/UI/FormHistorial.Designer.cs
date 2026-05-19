using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class FormHistorial
    {
        private System.ComponentModel.IContainer? components = null;

        // ── CONTROLES ─────────────────────────────────────────────────────────
        private MaterialLabel    lblTitulo      = null!;
        private FlowLayoutPanel  flpCompletadas = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo      = new MaterialLabel();
            flpCompletadas = new FlowLayoutPanel();

            SuspendLayout();
            flpCompletadas.SuspendLayout();

            // ── lblTitulo ─────────────────────────────────────────────────────
            lblTitulo.Text      = "TAREAS COMPLETADAS";
            lblTitulo.Font      = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(76, 175, 80);
            lblTitulo.Location  = new Point(24, 80);
            lblTitulo.AutoSize  = true;

            // ── flpCompletadas ────────────────────────────────────────────────
            flpCompletadas.Location      = new Point(24, 118);
            flpCompletadas.Size          = new Size(652, 376);
            flpCompletadas.AutoScroll    = true;
            flpCompletadas.BackColor     = Color.Transparent;
            flpCompletadas.FlowDirection = FlowDirection.LeftToRight;
            flpCompletadas.WrapContents  = true;

            // ── Ensamblado del formulario ─────────────────────────────────────
            Controls.Add(lblTitulo);
            Controls.Add(flpCompletadas);

            // ── Propiedades del formulario ────────────────────────────────────
            ClientSize    = new Size(700, 540);
            StartPosition = FormStartPosition.CenterParent;
            BackColor     = Color.FromArgb(32, 32, 32);
            Text          = "Historial de tareas completadas";

            flpCompletadas.ResumeLayout(performLayout: false);
            ResumeLayout(performLayout: false);
        }
    }
}
