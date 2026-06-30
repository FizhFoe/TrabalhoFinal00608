using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_UC00608
{
    public class Servico
    {
        public int IdServico { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public Servico(int idServico, string descricao, decimal preco)
        {
            this.IdServico = idServico;
            this.Descricao = descricao;
            this.Preco = preco;
        }

    }
}
