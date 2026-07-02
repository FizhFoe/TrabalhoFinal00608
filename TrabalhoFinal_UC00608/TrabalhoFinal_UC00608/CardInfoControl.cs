using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TrabalhoFinal_UC00608
{
    public class CardInfoControl : UserControl
    {
        private Label lblValor;
        private Label lblTitulo;
        private Label lblIcone;
        private Color corIcone = Color.FromArgb(30, 90, 200);

        public CardInfoControl()
        {
            this.MinimumSize = new Size(180, 100);
            this.Size = new Size(260, 110);
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            // Ícone: tamanho e posição fixos no canto superior esquerdo
            lblIcone = new Label
            {
                AutoSize = false,
                Size = new Size(44, 44),
                Location = new Point(14, 14),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = corIcone,
                BackColor = Color.Transparent,
                Text = "🔧"
            };

            // Valor: acompanha a largura do card (Left + Right anchor)
            // X começa em 82 (14 + 44 do ícone + 24 de espaço) para não sobrepor o ícone
            lblValor = new Label
            {
                AutoSize = false,
                Location = new Point(82, 12),
                Size = new Size(166, 32),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true,
                Padding = new Padding(0, 0, 8, 0),
                Text = "0"
            };

            // Título: também acompanha a largura, com reticências se não couber
            // Y começa em 62 (o ícone termina em 58) para não sobrepor o ícone verticalmente
            lblTitulo = new Label
            {
                AutoSize = false,
                Location = new Point(82, 62),
                Size = new Size(166, 32),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true,
                Padding = new Padding(0, 0, 8, 4),
                Text = "Título"
            };

            this.Controls.Add(lblIcone);
            this.Controls.Add(lblValor);
            this.Controls.Add(lblTitulo);

            this.Resize += (s, e) => this.Invalidate();
        }

        public string Titulo { get => lblTitulo.Text; set => lblTitulo.Text = value; }
        public string Valor { get => lblValor.Text; set => lblValor.Text = value; }
        public string Icone { get => lblIcone.Text; set => lblIcone.Text = value; }

        public Color CorIcone
        {
            get => corIcone;
            set { corIcone = value; lblIcone.ForeColor = value; this.Invalidate(); }
        }

        // Permite ajustar o tamanho da fonte do valor caso o card fique muito pequeno/grande
        public float TamanhoFonteValor
        {
            get => lblValor.Font.Size;
            set => lblValor.Font = new Font(lblValor.Font.FontFamily, value, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            int radius = 12;

            using (GraphicsPath path = GetRoundedRect(rect, radius))
            {
                this.Region = new Region(path);

                using (SolidBrush bg = new SolidBrush(this.BackColor))
                    e.Graphics.FillPath(bg, path);

                using (Pen border = new Pen(Color.FromArgb(230, 230, 230), 1))
                    e.Graphics.DrawPath(border, path);
            }

            Rectangle circleRect = new Rectangle(14, 14, 44, 44);
            Color circleBack = Color.FromArgb(255,
                Math.Min(255, corIcone.R + 190),
                Math.Min(255, corIcone.G + 190),
                Math.Min(255, corIcone.B + 190));

            using (SolidBrush circleBrush = new SolidBrush(circleBack))
                e.Graphics.FillEllipse(circleBrush, circleRect);

            base.OnPaint(e);
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}