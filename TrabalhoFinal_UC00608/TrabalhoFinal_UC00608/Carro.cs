using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_UC00608
{
    public class Carro : Veiculo
    {
        public Carro(int idVeiculo, string matricula, string marca, string modelo, int ano, string combustivel, Cliente dono): base(idVeiculo, matricula, marca, modelo, ano, combustivel, dono)
        {
        }

        public override bool verificarNecessidadeRevisao(double quilometragem)
        {
            if (quilometragem > 150000)
            {
                return true;
            }
            return false;
        }

        public override string mostrarDados()
        {
            return base.mostrarDados();
        }
    }
}
