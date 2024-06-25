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

        private List<Comida> listaComidas;

        /// Atribuir um novo pedido
        public Pedido()
        {
            TAXA_SERVICO = 0.1;
            listaComidas = new List<Comida>();
        }

        /// Adicionar nova comida no pedido
        public void addComida(Comida comida) { 
            listaComidas.Add(comida);
        }
        
        /// Método para relatório do pedido
        public string relatorio()
        {
            int count = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n#######-CONTA-FECHADA-#######");
            sb.AppendLine("\n> Itens pedidos:\n");
            foreach (Comida comida in listaComidas)
            {
                sb.AppendLine($"{count}° - {comida.ToString()}");
                count++;
            }
            sb.Append("\n> Preço total com taxa: ");
            return sb.ToString() + "R$: " + precoFinal().ToString("F2");
        }

        /// Método para retornar o preço final do pedido feito
        public double precoFinal()
        {
            return listaComidas.Sum(c => c.valor()) * (1 + TAXA_SERVICO);
        }
    }
}
