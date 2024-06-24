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

        public Pedido()
        {
            TAXA_SERVICO = 0.1;
            listaComidas = new List<Comida>();
        }

        public void addComida(Comida comida) { 
                listaComidas.Add(comida);
        }

        public string relatiorio()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Comida comida in listaComidas)
            {
                sb.AppendLine(comida.ToString());
            }

            return sb.ToString() + "\nR$: " + precoFinal().ToString("2F");
        }

        public double precoFinal()
        {
            return listaComidas.Sum(c => c.valor()) * (1 + TAXA_SERVICO);
        }
    }
}
