using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Comida
    {
        private string _nome;

        private double _valor;
        
        /// Cria nova comida
        public Comida(string nome, double valor)
        {
            _nome = nome;
            _valor = valor;
        }

        /// Método para retornar nome e valor da comida
        public override string ToString()
        {
            return $"{_nome}: R${Math.Round(_valor,2)}";
        }

        /// Método para retornar o valor da comida
        public double valor()
        {
            return _valor;
        }
    }
}
