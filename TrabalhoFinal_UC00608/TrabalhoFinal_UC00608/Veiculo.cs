using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;
using System.Text;

namespace TrabalhoFinal_UC00608
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Combustivel { get; set; }
        public Cliente Dono { get; set; }

        public Veiculo(int idVeiculo, string matricula, string marca, string modelo, int ano, string combustivel, Cliente dono)
        {
            this.IdVeiculo = idVeiculo;
            this.Matricula = matricula;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Combustivel = combustivel;
            this.Dono = dono;
        }
        //VerificarNecessidadeRevisao() é metodo poliformico
        public virtual bool verificarNecessidadeRevisao(double quilometragem)
        {
            if (quilometragem > 150000)
            {
                return true;
            }
            return false;
        }

        public int calcularIdadeVeiculo()
        {
            int anoAtual = DateTime.Now.Year; //vai buscar o ano atual do computador
            int idadeDoVeiculo = anoAtual - this.Ano;
            return idadeDoVeiculo;
        }


        public virtual string mostrarDados()
        {
            return "Matricula: " + this.Matricula + "\nMarca: " + this.Marca + "\nModelo: " + this.Modelo + "\nAno: " + this.Ano + "\nProprietario: " + this.Dono.Nome;
        }
    }
}
