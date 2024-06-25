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
        private bool disponivel;

        /// Determinar capacidade da mesa
        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            disponivel = true;
        }

        /// Verificar disponibilidade
        public bool disponibilidade()
        {
            return disponivel;
        }

        /// Verificar capacidade da mesa com a quantidade de pessoas 
        public bool verificarCapacidade(int quantidadePessoas)
        {
            return (quantidadePessoas <= capacidade) ? true : false;
        }   

        /// Alternar status da mesa, sua disponibilidade
        public void alternarStatus(){
            disponivel = !disponivel;
        }     
    }
}