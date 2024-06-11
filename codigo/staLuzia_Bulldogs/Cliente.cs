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

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public override string ToString(){
            return this.nome;
        }
    }
}
