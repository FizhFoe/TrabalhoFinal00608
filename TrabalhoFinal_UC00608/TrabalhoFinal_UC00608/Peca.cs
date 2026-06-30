using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_UC00608
{
    public class Peca
    {
        public int IdPeca { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Stock { get; set; }

        public Peca(int idPeca, string nome, decimal preco, int stock)
        {
            this.IdPeca = idPeca;
            this.Nome = nome;
            this.Preco = preco;
            this.Stock = stock;
        }
        public bool verificarStockDisponivel(int quantidadePedida)
        {
            return this.Stock >= quantidadePedida;
        }

        public void deduzirStock(int quantidade)
        {
            if (verificarStockDisponivel(quantidade))
            {
                this.Stock -= quantidade;
            }
            else
            {
                throw new InvalidOperationException($"Stock insuficiente para a peça: {this.Nome}");
            }
        }
    }
}
