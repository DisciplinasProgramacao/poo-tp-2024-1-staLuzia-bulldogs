using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    abstract class Cardapio
    {
        /// Criando cardápios para colocar nome e preço dos produtos de determinados estabelecimentos
        protected Dictionary<int, Comida> comidas = null!;

        /// Buscar determinada comida a partir de seu id
        public Comida produto(int idComida)
        {
            return comidas[idComida];
        }

        /// Menu do cardápio para o usuário escolher as opções desejadas
        public override string ToString()
        {
            int count = 1;
            StringBuilder sb = new StringBuilder();
                sb.AppendLine("===================MENU===================");
            sb.AppendLine("Esolha uma das opções a seguir: \n");
            foreach(Comida comida in comidas.Values)
            {
                sb.AppendLine($"{count}. {comida.ToString()}");
                count++;
            }
            sb.AppendLine($"{count}.Cancelar");
            sb.AppendLine("\n===========================================");

            return sb.ToString();
        }
        
        /// Método para retornar a quantidade de comidas no menu
        public int tamanho()
        {
            return comidas.Values.Count() + 1;
        }
    }
}