using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesa
{
    internal class Mesa
    {
        private int capacidade;
        private bool reserva;

        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            reserva = false;
        }
        public int ObterCapacidade()
        {
            return capacidade;
        }
        public bool verificarDisponivel()
        {
            if(reserva == false)
            {
                return true;
            }
            return false;
        }
        public bool verificarCapacidade(int quantidadePessoas)
        {
            if(quantidadePessoas <= ObterCapacidade())
            {
                return true;
            }
            return false;
        }        
    }
}