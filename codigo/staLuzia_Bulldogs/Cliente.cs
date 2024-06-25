using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class Cliente
    {
        private string nome;

        /// Cria novo cliente
        public Cliente(string nome)
        {
            this.nome = nome;
        }

        /// Método para retornar o nome do cliente
        public override string ToString(){
            return nome;
        }
    }
}
