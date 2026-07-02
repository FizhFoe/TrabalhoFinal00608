namespace TrabalhoFinal_UC00608
{
    public partial class forms1 : Form
    {
        public forms1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarCards();
        }

        private void btnNovoServico_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarCards()
        {
            pnlCards.Controls.Clear();

            var cards = new[]
            {
                new CardInfoControl { Titulo = "Abertas", Valor = "18", Icone = "📋", CorIcone = Color.FromArgb(30, 90, 200) },
                new CardInfoControl { Titulo = "Em Andamento", Valor = "05", Icone = "🔧", CorIcone = Color.FromArgb(230, 160, 20) },
                new CardInfoControl { Titulo = "Concluídas", Valor = "12", Icone = "✔️", CorIcone = Color.FromArgb(40, 170, 90) },
                new CardInfoControl { Titulo = "Faturamento (Mês)", Valor = "€ 10.700", Icone = "€", CorIcone = Color.FromArgb(220, 60, 60) },
                new CardInfoControl { Titulo = "Clientes Registados", Valor = "27", Icone = "👥", CorIcone = Color.FromArgb(140, 90, 220) }
            };

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Dock = DockStyle.Fill;
                cards[i].Margin = new Padding(8);
                pnlCards.Controls.Add(cards[i], i, 0);
            }
        }
    }
}
