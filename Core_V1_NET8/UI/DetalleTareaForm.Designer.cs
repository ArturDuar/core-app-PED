using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class DetalleTareaForm
    {
        private System.ComponentModel.IContainer? components = null;

        // ── CONTROLES ─────────────────────────────────────────────────────────
        private Panel         pnlBarra           = null!;
        private MaterialLabel lblPrioridadBadge  = null!;
        private MaterialLabel lblTitulo          = null!;
        private MaterialLabel lblFechaHora       = null!;
        private Panel         pnlSep             = null!;
        private MaterialLabel lblDescLabel        = null!;
        private MaterialLabel lblDescripcionValor = null!;
        private MaterialButton btnEditar          = null!;
        private MaterialButton btnEstado          = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlBarra           = new Panel();
            lblPrioridadBadge  = new MaterialLabel();
            lblTitulo          = new MaterialLabel();
            lblFechaHora       = new MaterialLabel();
            pnlSep             = new Panel();
            lblDescLabel       = new MaterialLabel();
            lblDescripcionValor = new MaterialLabel();
            btnEditar          = new MaterialButton();
            btnEstado          = new MaterialButton();

            SuspendLayout();

            // ── pnlBarra ──────────────────────────────────────────────────────
            // Se añade PRIMERO para que Dock=Top se resuelva antes que los
            // controles con coordenadas absolutas.
            pnlBarra.Dock      = DockStyle.Top;
            pnlBarra.Height    = 6;
            pnlBarra.BackColor = Color.FromArgb(80, 80, 80);  // sobreescrito en constructor

            // ── lblPrioridadBadge ─────────────────────────────────────────────
            lblPrioridadBadge.Text      = "";
            lblPrioridadBadge.Font      = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblPrioridadBadge.ForeColor = Color.FromArgb(80, 80, 80);  // sobreescrito
            lblPrioridadBadge.Location  = new Point(24, 76);
            lblPrioridadBadge.AutoSize  = true;

            // ── lblTitulo ─────────────────────────────────────────────────────
            lblTitulo.Text         = "";
            lblTitulo.Font         = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblTitulo.ForeColor    = Color.FromArgb(230, 230, 230);
            lblTitulo.Location     = new Point(24, 100);
            lblTitulo.Size         = new Size(452, 60);
            lblTitulo.AutoEllipsis = true;

            // ── lblFechaHora ──────────────────────────────────────────────────
            lblFechaHora.Text      = "";
            lblFechaHora.Font      = new Font("Segoe UI", 10f);
            lblFechaHora.ForeColor = Color.FromArgb(150, 150, 150);
            lblFechaHora.Location  = new Point(24, 166);
            lblFechaHora.AutoSize  = true;

            // ── pnlSep (separador) ────────────────────────────────────────────
            pnlSep.BackColor = Color.FromArgb(55, 55, 55);
            pnlSep.Location  = new Point(24, 196);
            pnlSep.Size      = new Size(452, 1);

            // ── lblDescLabel ──────────────────────────────────────────────────
            lblDescLabel.Text      = "DESCRIPCIÓN";
            lblDescLabel.Font      = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblDescLabel.ForeColor = Color.FromArgb(150, 150, 150);
            lblDescLabel.Location  = new Point(24, 210);
            lblDescLabel.AutoSize  = true;

            // ── lblDescripcionValor ───────────────────────────────────────────
            lblDescripcionValor.Text         = "";
            lblDescripcionValor.Font         = new Font("Segoe UI", 10f);
            lblDescripcionValor.ForeColor    = Color.FromArgb(230, 230, 230);
            lblDescripcionValor.Location     = new Point(24, 232);
            lblDescripcionValor.Size         = new Size(452, 120);
            lblDescripcionValor.AutoEllipsis = true;

            // ── btnEditar ─────────────────────────────────────────────────────
            btnEditar.Text           = "✏  EDITAR";
            btnEditar.Type           = MaterialButton.MaterialButtonType.Outlined;
            btnEditar.UseAccentColor = false;
            btnEditar.Location       = new Point(24, 390);
            btnEditar.Size           = new Size(140, 36);
            btnEditar.Visible        = true;   // sobreescrito en constructor según esPendiente

            // ── btnEstado ─────────────────────────────────────────────────────
            btnEstado.Text           = "✔  MARCAR COMPLETADA";   // sobreescrito en constructor
            btnEstado.Type           = MaterialButton.MaterialButtonType.Contained;
            btnEstado.UseAccentColor = true;
            btnEstado.ForeColor      = Color.FromArgb(20, 20, 20);
            btnEstado.Location       = new Point(180, 390);       // sobreescrito en constructor
            btnEstado.Size           = new Size(200, 36);         // sobreescrito en constructor

            // ── Ensamblado del formulario ─────────────────────────────────────
            // pnlBarra se añade AL ÚLTIMO para que quede en el frente del z-order.
            // En WinForms, Controls.Add inserta en índice 0 (frente) y empuja
            // los anteriores hacia atrás; el primero añadido termina siendo el más trasero.
            Controls.Add(lblPrioridadBadge);
            Controls.Add(lblTitulo);
            Controls.Add(lblFechaHora);
            Controls.Add(pnlSep);
            Controls.Add(lblDescLabel);
            Controls.Add(lblDescripcionValor);
            Controls.Add(btnEditar);
            Controls.Add(btnEstado);
            Controls.Add(pnlBarra);   // ← último = primer plano, Dock=Top visible

            // ── Propiedades del formulario ────────────────────────────────────
            ClientSize    = new Size(500, 460);
            StartPosition = FormStartPosition.CenterParent;
            BackColor     = Color.FromArgb(32, 32, 32);
            Text          = "Detalle de tarea";

            ResumeLayout(performLayout: false);
        }
    }
}
