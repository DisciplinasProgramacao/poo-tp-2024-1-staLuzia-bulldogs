using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class Cardapio
    {
        private Dictionary<int, Comida> comidas;
        public Cardapio(ETipo tipo)
        {
            string[,] itens;
            comidas = new Dictionary<int, Comida>();

            if (tipo.Equals(ETipo.cafeteria))
            {
                itens = new string[,]
                    {
                        {"Pão de queijo", "5"},
                        {"Bolinha de cogumelo", "7"},
                        {"Risole de palimito", "7"},
                        {"Coxinha de carne de jaca", "8"},
                        {"Fatia de queijo de caju", "9"},
                        {"Biscoito amantegado", "3"},
                        {"Cheesecake de frutas vermelhas", "15"},
                        {"Água", "3"},
                        {"Copo de suco", "7"},
                        {"Café espresso orgânico", "6"},
                    };
            }
            else if(tipo.Equals(ETipo.restaurante))
            {
                itens = new string[,]
                {
                        {"Moqueca de Palmito", "32"},
                        {"Falafel Assado", "20"},
                        {"Salada Primavera com Macarrão Konjac", "32"},
                        {"Escondidinho de Inhame", "32"},
                        {"Strogonoff de Cogumelos", "32"},
                        {"Caçarola de legumes", "32"},
                        {"Água", "3"},
                        {"Copo de suco", "7"},
                        {"Refrigerante orgânico", "7"},
                        {"Cerveja vegana", "9"},
                        {"Taça de vinho vegano", "18"},
                };
            }
            else{
                itens = new string[0,0];
            }

            for (int i = 1; i <= itens.GetUpperBound(0); i++)
            {
                comidas.Add(i, new Comida(itens[i, 0], Convert.ToDouble(itens[i, 1])));
            };

        }

        public Comida produto(int idComida)
        {
            return comidas[idComida];
        }
    }
}