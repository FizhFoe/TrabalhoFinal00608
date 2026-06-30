using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_UC00608
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }

        public Cliente(int idCliente, string nome, string nif, string telefone, string email, string morada)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.NIF = nif;
            this.Telefone = telefone;
            this.Email = email;
            this.Morada = morada;
        }


        public string mostrarDados()
        {
            return "ID Cliente: " + this.IdCliente + "\nNome: " + this.Nome + "\nNIF: " + this.NIF + "\nTelefone: " + this.Telefone + "\nEmail: " + this.Email + "\nMorada: " + this.Morada;
        }


    }

}
