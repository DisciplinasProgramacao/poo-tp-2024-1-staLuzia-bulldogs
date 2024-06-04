using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class Mesa
    {
        private int capacidade;
        private bool reservado;

        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            reserva = false;
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
            if(quantidadePessoas <= capacidade)
            {
                return true;
            }
            return false;
        }   

        public void alternarStatus(bool status){
            reservado = status;
        }     
    }
}