using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrabalhoFinal_UC00608
{
    public class Reparacao
    {
        public int IdReparacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; } // O '?' permite null no C# caso o carro ainda esteja na oficina
        public string Estado { get; set; }
        public string Observacoes { get; set; }
        public Veiculo VeiculoAssociado { get; set; }
        public Funcionario FuncionarioResponsavel { get; set; }

        public Dictionary<Peca, int> PecasUtilizadas { get; set; } // Guarda a peça e a quantidade usada
        public Dictionary<Servico, int> ServicosEfetuados { get; set; } // Guarda o serviço e a quantidade

        public Reparacao(int idReparacao, DateTime dataEntrada, string estado, string observacoes, Veiculo veiculo, Funcionario funcionario)
        {
            this.IdReparacao = idReparacao;
            this.DataEntrada = dataEntrada;
            this.DataSaida = null;
            this.Estado = estado;
            this.Observacoes = observacoes;
            this.VeiculoAssociado = veiculo;
            this.FuncionarioResponsavel = funcionario;

            this.PecasUtilizadas = new Dictionary<Peca, int>();
            this.ServicosEfetuados = new Dictionary<Servico, int>();
        }

        public void adicionarPeca(Peca peca, int quantidade)
        {
            if (peca.verificarStockDisponivel(quantidade))
            {
                peca.deduzirStock(quantidade);
                if (this.PecasUtilizadas.ContainsKey(peca))
                    this.PecasUtilizadas[peca] += quantidade;
                else
                    this.PecasUtilizadas.Add(peca, quantidade);
            }
        }

        public void adicionarServico(Servico servico, int quantidade = 1)
        {
            if (this.ServicosEfetuados.ContainsKey(servico))
                this.ServicosEfetuados[servico] += quantidade;
            else
                this.ServicosEfetuados.Add(servico, quantidade);
        }

        public void concluirReparacao(DateTime dataSaida)
        {
            this.DataSaida = dataSaida;
            this.Estado = "Concluído";
        }

        public decimal calcularCustoTotal()
        {
            // O Sum() percorre o dicionário, faz a multiplicação e soma tudo automaticamente
            decimal totalPecas = PecasUtilizadas.Sum(par => par.Key.Preco * par.Value);
            decimal totalServicos = ServicosEfetuados.Sum(par => par.Key.Preco * par.Value);

            return totalPecas + totalServicos;
        }
    }
}
