using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Pedido
    {
        private static double TAXA_SERVICO;

        private double _valorTotal;

        private List<Comida> listaComidas = new List<Comida>();

        public Pedido() 
        {
            TAXA_SERVICO = 0.1;
        }

        public void addComida(string nome, double valor, int quantidade)
        {
            for(int i = 0;  i < quantidade; i++) 
            {
                Comida comida = new Comida(nome, valor);
                listaComidas.Add(comida);
            }
            atualizarValor(valor, quantidade);
        }

        private void atualizarValor(double valor, int quantidade)
        {
            _valorTotal += valor * quantidade;
        }

        public string relatiorio()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Comida comida in listaComidas)
            {
                sb.AppendLine(comida.ToString());
            }

            return sb.ToString() + "\nR$: " + precoFinal().ToString();
        }

        public double precoFinal()
        {
            return _valorTotal *= TAXA_SERVICO;
        }
    }
}
