using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class TareaCard
    {
        private System.ComponentModel.IContainer? components = null;

        // ── CONTROLES ─────────────────────────────────────────────────────────
        private Panel         pnlBarra          = null!;
        private Label         lblBadgePrioridad = null!;
        private Label         lblUrgenteBadge   = null!;
        private MaterialLabel lblTitulo         = null!;
        private MaterialLabel lblFechaHora      = null!;
        private MaterialButton btnVerMas        = null!;
        private Button         btnBorrar        = null!;
        private Panel          pnlSep           = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlBarra          = new Panel();
            lblBadgePrioridad = new Label();
            lblUrgenteBadge   = new Label();
            lblTitulo         = new MaterialLabel();
            lblFechaHora      = new MaterialLabel();
            btnVerMas         = new MaterialButton();
            btnBorrar         = new Button();
            pnlSep            = new Panel();

            SuspendLayout();

            // ── pnlBarra ───────────────────────────────────────────────────────
            pnlBarra.Dock      = DockStyle.Top;
            pnlBarra.Height    = 5;
            pnlBarra.BackColor = Color.FromArgb(80, 80, 80);

            // ── lblBadgePrioridad ──────────────────────────────────────────────
            lblBadgePrioridad.Text      = "NORMAL";
            lblBadgePrioridad.Font      = new Font("Segoe UI", 7f, FontStyle.Bold);
            lblBadgePrioridad.ForeColor = Color.FromArgb(76, 175, 80);
            lblBadgePrioridad.BackColor = Color.Transparent;
            lblBadgePrioridad.AutoSize  = true;
            lblBadgePrioridad.Location  = new Point(12, 14);

            // ── lblUrgenteBadge ────────────────────────────────────────────────
            lblUrgenteBadge.Text      = "★  MÁS URGENTE";
            lblUrgenteBadge.Font      = new Font("Segoe UI", 7f, FontStyle.Bold);
            lblUrgenteBadge.ForeColor = Color.FromArgb(207, 102, 121);
            lblUrgenteBadge.BackColor = Color.FromArgb(60, 207, 102, 121);
            lblUrgenteBadge.AutoSize  = true;
            lblUrgenteBadge.Visible   = false;
            lblUrgenteBadge.Padding   = new Padding(4, 2, 4, 2);
            lblUrgenteBadge.Location  = new Point(CARD_WIDTH - 126, 10);

            // ── lblTitulo ─────────────────────────────────────────────────────
            lblTitulo.Text         = "";
            lblTitulo.Font         = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTitulo.ForeColor    = Color.FromArgb(240, 240, 240);
            lblTitulo.BackColor    = Color.Transparent;
            lblTitulo.Location     = new Point(12, 34);
            lblTitulo.Size         = new Size(CARD_WIDTH - 24, 28);
            lblTitulo.AutoEllipsis = true;

            // ── lblFechaHora ──────────────────────────────────────────────────
            lblFechaHora.Text      = "";
            lblFechaHora.Font      = new Font("Segoe UI", 8.5f);
            lblFechaHora.ForeColor = Color.FromArgb(170, 170, 170);
            lblFechaHora.BackColor = Color.Transparent;
            lblFechaHora.Location  = new Point(12, 66);
            lblFechaHora.AutoSize  = true;

            // ── pnlSep ────────────────────────────────────────────────────────
            pnlSep.BackColor = Color.FromArgb(55, 55, 55);
            pnlSep.Size      = new Size(CARD_WIDTH - 24, 1);
            pnlSep.Location  = new Point(12, CARD_HEIGHT - 50);

            // ── btnVerMas ─────────────────────────────────────────────────────
            btnVerMas.Text           = "VER MÁS";
            btnVerMas.Type           = MaterialButton.MaterialButtonType.Outlined;
            btnVerMas.UseAccentColor = false;
            btnVerMas.Size           = new Size(100, 30);
            btnVerMas.Location       = new Point(12, CARD_HEIGHT - 44);
            btnVerMas.Margin         = new Padding(0);
            btnVerMas.HighEmphasis   = false;

            // ── btnBorrar ─────────────────────────────────────────────────────
            btnBorrar.Text      = "✕";
            btnBorrar.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBorrar.ForeColor = Color.FromArgb(180, 180, 180);
            btnBorrar.BackColor = Color.Transparent;
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.Size      = new Size(30, 30);
            btnBorrar.Location  = new Point(CARD_WIDTH - 42, CARD_HEIGHT - 44);
            btnBorrar.Cursor    = Cursors.Hand;
            btnBorrar.TabStop   = false;
            btnBorrar.FlatAppearance.BorderSize          = 0;
            btnBorrar.FlatAppearance.MouseOverBackColor  = Color.FromArgb(60, 255, 80, 80);
            btnBorrar.FlatAppearance.MouseDownBackColor  = Color.FromArgb(100, 255, 80, 80);

            // ── Ensamblado del control ─────────────────────────────────────────
            // pnlBarra se añade AL ÚLTIMO para que quede en el frente del z-order.
            // En WinForms Controls.Add inserta en índice 0 (frente) y desplaza
            // los anteriores hacia atrás; la barra Dock=Top debe verse encima de todo.
            Controls.Add(lblBadgePrioridad);
            Controls.Add(lblUrgenteBadge);
            Controls.Add(lblTitulo);
            Controls.Add(lblFechaHora);
            Controls.Add(pnlSep);
            Controls.Add(btnVerMas);
            Controls.Add(btnBorrar);
            Controls.Add(pnlBarra);   // ← último = primer plano, Dock=Top visible

            // ── Propiedades del UserControl ────────────────────────────────────
            BackColor = Color.FromArgb(36, 36, 36);
            Size      = new Size(CARD_WIDTH, CARD_HEIGHT);
            Margin    = new Padding(8);
            Cursor    = Cursors.Default;

            ResumeLayout(performLayout: false);
        }
    }
}
