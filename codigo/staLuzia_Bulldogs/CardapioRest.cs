using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class CardapioRest : Cardapio
    {
        private string[] nomeComidas =
            {"Moqueca de Palmito",
            "Falafel Assado",
            "Salada Primavera com Macarrão Konjac",
            "Escondidinho de Inhame",
            "Strogonoff de Cogumelos",
            "Caçarola de legumes",
            "Água",
            "Copo de suco",
            "Refrigerante orgânico",
            "Cerveja vegana",
            "Taça de vinho vegano"};

        private double[] precoComidas = {32,20,25,18,35,22,3,7,7,9,18};

        public CardapioRest()
        {
            comidas = new Dictionary<int, Comida>();

            for (int i = 0; i < nomeComidas.Length; i++)
            {
                comidas.Add(i + 1, new Comida(nomeComidas[i], precoComidas[i]));
            }
        }

        
    }
}
