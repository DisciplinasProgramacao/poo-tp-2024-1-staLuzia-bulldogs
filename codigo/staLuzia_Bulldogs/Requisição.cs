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
        private int quantPessoas;
        private Mesa mesa;
        private Pedido pedido;
        private bool status;

        public Requisicao(int quantPessoas, Mesa mesa)
        {
            this.quantPessoas = quantPessoas;
            this.mesa = mesa;
            pedido = new Pedido();
            status = false;
        }

        public bool verificarStatus(){
            return status;
        }

        public Mesa obterMesa(){
            return mesa;
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
            return (status == true) ? status = false : status = true;
        }

        public void updatePedido(string nome, int valor, int qnt){
            pedido.addComida(nome, valor, qnt);
        }

        public string fecharPedido(){
            return pedido.relatiorio() + "\nData Entrada: " + dataEntrada + "\nData Saída:" + dataSaida;
        }
    }
}
