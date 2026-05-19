using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class DetalleTareaForm
    {
        private System.ComponentModel.IContainer? components = null;

        // ── CONTROLES ─────────────────────────────────────────────────────────
        private Panel                     pnlBarra           = null!;
        private Label                     lblPrioridadBadge  = null!;
        private MaterialTextBox           txtTitulo          = null!;
        private Label                     lblFechaHora       = null!;
        private Panel                     pnlSep             = null!;
        private Label                     lblDescLabel       = null!;
        private MaterialMultiLineTextBox2 txtDescripcion     = null!;
        private MaterialButton            btnEditar          = null!;
        private MaterialButton            btnEstado          = null!;

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
            lblPrioridadBadge  = new Label();
            txtTitulo          = new MaterialTextBox();
            lblFechaHora       = new Label();
            pnlSep             = new Panel();
            lblDescLabel       = new Label();
            txtDescripcion     = new MaterialMultiLineTextBox2();
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
            lblPrioridadBadge.ForeColor = Color.FromArgb(150, 150, 150);
            lblPrioridadBadge.BackColor = Color.Transparent;
            lblPrioridadBadge.Location  = new Point(24, 76);
            lblPrioridadBadge.AutoSize  = true;

            // ── txtTitulo (readonly) ──────────────────────────────────────────
            txtTitulo.Text            = "";
            txtTitulo.Hint            = "";
            txtTitulo.Font            = new Font("Roboto", 18f, FontStyle.Bold, GraphicsUnit.Pixel);
            txtTitulo.Location        = new Point(24, 94);
            txtTitulo.Size            = new Size(452, 50);
            txtTitulo.ReadOnly        = true;
            txtTitulo.AnimateReadOnly = false;
            txtTitulo.BorderStyle     = BorderStyle.None;
            txtTitulo.Depth           = 0;
            txtTitulo.MouseState      = MaterialSkin.MouseState.OUT;
            txtTitulo.TabStop         = false;

            // ── lblFechaHora ──────────────────────────────────────────────────
            lblFechaHora.Text      = "";
            lblFechaHora.Font      = new Font("Segoe UI", 10f);
            lblFechaHora.ForeColor = Color.FromArgb(150, 150, 150);
            lblFechaHora.BackColor = Color.Transparent;
            lblFechaHora.Location  = new Point(24, 154);
            lblFechaHora.AutoSize  = true;

            // ── pnlSep (separador) ────────────────────────────────────────────
            pnlSep.BackColor = Color.FromArgb(70, 100, 130);
            pnlSep.Location  = new Point(24, 182);
            pnlSep.Size      = new Size(452, 1);

            // ── lblDescLabel ──────────────────────────────────────────────────
            lblDescLabel.Text      = "DESCRIPCIÓN";
            lblDescLabel.Font      = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblDescLabel.ForeColor = Color.FromArgb(150, 150, 150);
            lblDescLabel.BackColor = Color.Transparent;
            lblDescLabel.Location  = new Point(24, 196);
            lblDescLabel.AutoSize  = true;

            // ── txtDescripcion (readonly, multilinea) ─────────────────────────
            txtDescripcion.Hint       = "";
            txtDescripcion.Location   = new Point(24, 216);
            txtDescripcion.Size       = new Size(452, 130);
            txtDescripcion.ReadOnly   = true;
            txtDescripcion.Depth      = 0;
            txtDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            txtDescripcion.TabStop    = false;

            // ── btnEditar ─────────────────────────────────────────────────────
            // txtDescripcion.Bottom = 216+130 = 346 → botones en 346+18 = 364
            btnEditar.Text           = "✏  EDITAR";
            btnEditar.Type           = MaterialButton.MaterialButtonType.Outlined;
            btnEditar.UseAccentColor = false;
            btnEditar.Location       = new Point(24, 364);
            btnEditar.Size           = new Size(140, 36);
            btnEditar.Visible        = true;

            // ── btnEstado ─────────────────────────────────────────────────────
            btnEstado.Text           = "✔  MARCAR COMPLETADA";
            btnEstado.Type           = MaterialButton.MaterialButtonType.Contained;
            btnEstado.UseAccentColor = true;
            btnEstado.ForeColor      = Color.FromArgb(20, 20, 20);
            btnEstado.Location       = new Point(180, 364);
            btnEstado.Size           = new Size(220, 36);

            // ── Ensamblado del formulario ─────────────────────────────────────
            // pnlBarra se añade AL ÚLTIMO para que quede en el frente del z-order.
            // En WinForms, Controls.Add inserta en índice 0 (frente) y empuja
            // los anteriores hacia atrás; el primero añadido termina siendo el más trasero.
            Controls.Add(lblPrioridadBadge);
            Controls.Add(txtTitulo);
            Controls.Add(lblFechaHora);
            Controls.Add(pnlSep);
            Controls.Add(lblDescLabel);
            Controls.Add(txtDescripcion);
            Controls.Add(btnEditar);
            Controls.Add(btnEstado);
            Controls.Add(pnlBarra);   // ← último = primer plano, Dock=Top visible

            // ── Propiedades del formulario ────────────────────────────────────
            ClientSize    = new Size(500, 420);
            StartPosition = FormStartPosition.CenterParent;
            BackColor     = Color.FromArgb(32, 32, 32);
            Text          = "Detalle de tarea";

            ResumeLayout(performLayout: false);
        }
    }
}
