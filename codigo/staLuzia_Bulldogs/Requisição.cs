using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Requisicao
    {
        private DateTime dataEntrada;
        private DateTime dataSaida;
        private Cliente cliente;
        private int quantPessoas;
        private Mesa mesa;
        public Requisicao(Cliente cliente, int quantPessoas, Mesa mesa)
        {
            this.cliente = cliente;
            this.quantPessoas = quantPessoas;
            this.mesa  = mesa;
        }

        public void registrarEntrada(DateTime dataEntrada)
        {
            this.dataEntrada = DateTime.Now;
        }
        public void registrarSaida(DateTime dataSaida)
        {
            dataSaida = DateTime.Now;
        }
        public bool alternarStatus()
        {
            if(statusReserva()==true)
            {
                return false;
            }
            return true;
        }
        public Mesa obterMesa()
        {
            return mesa;
        }
        public bool statusReserva()
        {
            return mesa.verificarDisponivel();
        }
        public bool verificarStatus()
        {
           return statusReserva();
        }
    }
}
