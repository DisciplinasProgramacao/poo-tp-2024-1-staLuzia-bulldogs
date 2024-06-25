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

        /// Atribuir nova requisição
        public Requisicao(int qntPessoas, Cliente cliente)
        {
            dataEntrada = DateTime.Now;
            this.qntPessoas = qntPessoas;
            this.cliente = cliente;
            mesa = null!;
            pedido = new Pedido();
        }

        /// Método para ocupar uma mesa
        public void ocuparMesa(Mesa mesa){
            this.mesa = mesa;
        }

        /// Método para obter quantidade de pessoas
        public int obterQuantidade()
        {
            return qntPessoas;
        }

        /// Método para registrar saída do cliente
        public void registrarSaida()
        {
            dataSaida = DateTime.Now;
        }

        /// Método para adicionar nova comida no pedido
        public void updatePedido(Comida comida)
        {
            pedido.addComida(comida);
        }

        /// Método para fechar o pedido do cliente
        public string fecharPedido()
        {
            mesa.alternarStatus();
            registrarSaida();
            return pedido.relatorio() + "\nData Entrada: " + dataEntrada + "\nData Saída:" + dataSaida;
        }

        public override string ToString()
        {
            return mesa.ToString()!;
        }
    }
}
