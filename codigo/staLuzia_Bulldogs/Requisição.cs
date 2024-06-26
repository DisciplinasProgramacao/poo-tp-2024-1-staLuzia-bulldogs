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
        public Mesa getMesa(){
            return mesa;
        }

        /// Método para ocupar uma mesa
        public void ocuparMesa(Mesa mesa)
        {
            this.mesa = mesa;
            mesa.alternarStatus();
        }

        public Cliente dono()
        {
            return cliente;
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

        public void fecharPedido()
        {
            if (mesa != null)
                mesa.alternarStatus();
            registrarSaida();
        }

        /// Método para fechar o pedido do cliente
        public string resumoPedido()
        {
            return pedido.relatorio() + "\n\n> Data Entrada: " + dataEntrada + "\n> Data Saída: " + dataSaida;
        }

        public override string ToString()
        {
            return mesa.ToString()!;
        }
    }
}
