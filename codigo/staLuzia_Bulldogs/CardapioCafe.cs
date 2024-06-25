using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class CardapioCafe : Cardapio
    {
        private string [] nomeComidas =
            {"Não de queijo",
            "Bolinha de cogumelo",
            "Rissole de palimito",
            "Coxinha de carne de jaca",
            "Fatia de queijo de caju",
            "Biscoito amantegado",
            "Cheesecake de frutas vermelhas",
            "Água",
            "Copo de suco",
            "Café espresso orgânico"};
    
        private double [] precoComidas = { 5,7,7,8,9,3,15,3,7,6 };

        public CardapioCafe()
        {
            comidas = new Dictionary<int, Comida>();

            for (int i = 0; i < nomeComidas.Length; i++)
            {
                comidas.Add(i+1, new Comida(nomeComidas[i], precoComidas[i]));
            }
        }
        
    }
}
