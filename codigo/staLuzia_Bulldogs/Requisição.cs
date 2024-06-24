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
        private int qntPessoas;
        private Cliente cliente;
        private Mesa mesa;
        private Pedido pedido;
        private bool status;

        public Requisicao(int qntPessoas, Cliente cliente)
        {
            dataEntrada = DateTime.Now;
            this.qntPessoas = qntPessoas;
            this.cliente = cliente;
            mesa = null!;
            pedido = new Pedido();
            status = false;
        }

        public void ocuparMesa(Mesa mesa){
            this.mesa = mesa;
        }

        public bool verificarStatus()
        {
            return status;
        }

        public int obterQuantidade()
        {
            return qntPessoas;
        }

        public Mesa obterMesa()
        {
            return mesa;
        }

        public void registrarSaida()
        {
            dataSaida = DateTime.Now;
        }

        public void alternarStatus()
        {
            status = !status;
        }

        public void updatePedido(Comida comida)
        {
            pedido.addComida(comida);
        }

        public string fecharPedido()
        {
            registrarSaida();
            obterMesa().alternarStatus(false);
            return pedido.relatorio() + "\nData Entrada: " + dataEntrada + "\nData Saída:" + dataSaida;
        }
    }
}
