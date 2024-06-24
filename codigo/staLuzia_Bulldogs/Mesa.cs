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

        /// Determinar capacidade da mesa
        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            reservado = false;
        }

        /// Verificar disponibilidade
        public bool disponibilidade()
        {
            return !reservado;
        }

        /// Verificar capacidade da mesa com a quantidade de pessoas 
        public bool verificarCapacidade(int quantidadePessoas)
        {
            if(quantidadePessoas <= capacidade)
            {
                return true;
            }
            return false;
        }   

        /// Alternar status da mesa, sua disponibilidade
        public void alternarStatus(bool status){
            reservado = status;
        }     
    }
}