using MaterialSkin.Controls;

namespace Core_V1_NET8.UI
{
    partial class TareaDestacadaCard
    {
        private System.ComponentModel.IContainer? components = null;

        // ── CONTROLES ─────────────────────────────────────────────────────────
        private Panel         pnlBarra          = null!;
        private Label         lblBadge          = null!;
        private Label         lblHeader         = null!;
        private Label         lblTitulo         = null!;
        private Label         lblDetalle        = null!;
        private Panel         pnlSep1           = null!;
        private Panel         pnlSep2           = null!;
        private Label         lblFecha          = null!;
        private Label         lblHora           = null!;
        private Label         lblRegistro       = null!;
        private Panel         pnlDivider        = null!;
        private MaterialButton btnCompletar     = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlBarra   = new Panel();
            lblBadge   = new Label();
            lblHeader  = new Label();
            lblTitulo  = new Label();
            lblDetalle = new Label();
            pnlSep1    = new Panel();
            pnlSep2    = new Panel();
            lblFecha   = new Label();
            lblHora    = new Label();
            lblRegistro  = new Label();
            pnlDivider   = new Panel();
            btnCompletar = new MaterialButton();

            SuspendLayout();

            // ── pnlBarra — franja de color superior (Dock=Top) ────────────────
            pnlBarra.Dock      = DockStyle.Top;
            pnlBarra.Height    = 5;
            pnlBarra.BackColor = Color.FromArgb(80, 80, 80);

            // ── lblHeader — "★  TAREA MÁS URGENTE" ───────────────────────────
            lblHeader.Text      = "★  TAREA MÁS URGENTE";
            lblHeader.Font      = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(207, 102, 121);
            lblHeader.BackColor = Color.Transparent;
            lblHeader.AutoSize  = true;
            lblHeader.Location  = new Point(12, 14);

            // ── lblBadge — pill de prioridad ──────────────────────────────────
            lblBadge.Text      = "URGENTE";
            lblBadge.Font      = new Font("Segoe UI", 7f, FontStyle.Bold);
            lblBadge.ForeColor = Color.White;
            lblBadge.BackColor = Color.FromArgb(207, 102, 121);
            lblBadge.AutoSize  = true;
            lblBadge.Padding   = new Padding(6, 2, 6, 2);
            lblBadge.Location  = new Point(CARD_WIDTH - 130, 10);

            // ── pnlSep1 — línea bajo el header ───────────────────────────────
            pnlSep1.BackColor = Color.FromArgb(70, 100, 130);
            pnlSep1.Location  = new Point(12, 40);
            pnlSep1.Size      = new Size(CARD_WIDTH - 24, 1);

            // ── lblTitulo — título principal ──────────────────────────────────
            lblTitulo.Text         = "—";
            lblTitulo.Font         = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblTitulo.ForeColor    = Color.FromArgb(245, 245, 245);
            lblTitulo.BackColor    = Color.Transparent;
            lblTitulo.Location     = new Point(12, 50);
            lblTitulo.Size         = new Size(CARD_WIDTH - 24, 90);
            lblTitulo.AutoEllipsis = true;

            // ── lblDetalle — descripción ──────────────────────────────────────
            lblDetalle.Text      = "";
            lblDetalle.Font      = new Font("Segoe UI", 9.5f);
            lblDetalle.ForeColor = Color.FromArgb(160, 160, 160);
            lblDetalle.BackColor = Color.Transparent;
            lblDetalle.Location  = new Point(12, 146);
            lblDetalle.Size      = new Size(CARD_WIDTH - 24, 100);

            // ── pnlSep2 — línea sobre fecha/hora ─────────────────────────────
            pnlSep2.BackColor = Color.FromArgb(70, 100, 130);
            pnlSep2.Location  = new Point(12, 254);
            pnlSep2.Size      = new Size(CARD_WIDTH - 24, 1);

            // ── lblFecha / lblHora ────────────────────────────────────────────
            lblFecha.Text      = "📅  DD/MM/YYYY";
            lblFecha.Font      = new Font("Segoe UI", 8.5f);
            lblFecha.ForeColor = Color.FromArgb(140, 140, 140);
            lblFecha.BackColor = Color.Transparent;
            lblFecha.AutoSize  = true;
            lblFecha.Location  = new Point(12, 262);

            lblHora.Text      = "⏰  00:00";
            lblHora.Font      = new Font("Segoe UI", 8.5f);
            lblHora.ForeColor = Color.FromArgb(140, 140, 140);
            lblHora.BackColor = Color.Transparent;
            lblHora.AutoSize  = true;
            lblHora.Location  = new Point(CARD_WIDTH / 2, 262);

            // ── pnlDivider — separador antes del botón ───────────────────────
            pnlDivider.BackColor = Color.FromArgb(70, 100, 130);
            pnlDivider.Location  = new Point(0, CARD_HEIGHT - 52);
            pnlDivider.Size      = new Size(CARD_WIDTH, 1);

            // ── btnCompletar — CTA principal ──────────────────────────────────
            btnCompletar.Text           = "✓   MARCAR COMO COMPLETADA";
            btnCompletar.Type           = MaterialButton.MaterialButtonType.Contained;
            btnCompletar.UseAccentColor = true;
            btnCompletar.HighEmphasis   = true;
            btnCompletar.Size           = new Size(CARD_WIDTH - 24, 36);
            btnCompletar.Location       = new Point(12, CARD_HEIGHT - 46);
            btnCompletar.Margin         = new Padding(0);

            // ── Ensamblado ────────────────────────────────────────────────────
            // pnlBarra AL ÚLTIMO → Dock=Top visible al frente del z-order.
            Controls.Add(lblHeader);
            Controls.Add(lblBadge);
            Controls.Add(pnlSep1);
            Controls.Add(lblTitulo);
            Controls.Add(lblDetalle);
            Controls.Add(pnlSep2);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(pnlDivider);
            Controls.Add(btnCompletar);
            Controls.Add(pnlBarra);   // ← último = primer plano

            // ── Propiedades del UserControl ────────────────────────────────────
            BackColor = Color.FromArgb(28, 38, 48);
            Size      = new Size(CARD_WIDTH, CARD_HEIGHT);
            Margin    = new Padding(0);
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            ResumeLayout(performLayout: false);
        }
    }
}
