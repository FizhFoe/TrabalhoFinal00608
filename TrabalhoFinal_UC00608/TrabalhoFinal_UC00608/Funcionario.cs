using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_UC00608
{
    public class Funcionario
    {

        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public decimal Salario { get; set; }

        public Funcionario(int idFuncionario, string nome, string cargo, string telefone, decimal salario)
        {
            this.IdFuncionario = idFuncionario;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Salario = salario;

            List<string> cargosValidos = new List<string> { "Mecânico", "Rececionista", "Gerente" };
            if (cargosValidos.Contains(cargo))
            {
                this.Cargo = cargo;
            }
            else
            {
                this.Cargo = "Auxiliar";
            }
        }

        public string obterResumoFuncionario()
        {
            return $"{this.Nome} ({this.Cargo}) - Tel: {this.Telefone}";
        }

    }
}
