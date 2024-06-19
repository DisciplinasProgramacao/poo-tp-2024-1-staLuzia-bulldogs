using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class Cardapio
    {
        private Dictionary<int, Comida> comidasRestaurante;

        public Cardapio()
        {
            comidasRestaurante = new Dictionary<int, Comida>(){
                {1, new Comida ("Moqueca de Palmito", 32)},
                {2, new Comida("Falafel Assado", 20)},
                {3, new Comida("Salada Primavera com Macarrão Konjac", 32)},
                {4, new Comida("Escondidinho de Inhame", 32)},
                {5, new Comida("Strogonoff de Cogumelos", 32)},
                {6, new Comida("Caçarola de legumes", 32)},
                {7, new Comida("Água", 3)},
                {8, new Comida("Copo de suco", 7)},
                {9, new Comida("Refrigerante orgânico", 7)},
                {10, new Comida("Cerveja vegana", 9)},
                {11, new Comida("Taça de vinho vegano", 18)},
            };

        }
    }
}