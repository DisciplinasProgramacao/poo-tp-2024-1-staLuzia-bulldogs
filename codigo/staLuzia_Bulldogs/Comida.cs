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

        public Comida(string nome, double valor)
        {
            _nome = nome;
            _valor = valor;
        }

        public override string ToString()
        {
            return $"{_nome}: R${Math.Round(_valor,2)}";
        }

        public double valor()
        {
            return _valor;
        }
    }
}
