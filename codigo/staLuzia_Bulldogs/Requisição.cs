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

        /// Atribuir nova requisição
        public Requisicao(int qntPessoas, Cliente cliente)
        {
            dataEntrada = DateTime.Now;
            this.qntPessoas = qntPessoas;
            this.cliente = cliente;
            mesa = null!;
            pedido = new Pedido();
            status = false;
        }

        /// Método para ocupar uma mesa
        public void ocuparMesa(Mesa mesa){
            this.mesa = mesa;
        }

        /// Método para verificar o status da mesa
        public bool verificarStatus()
        {
            return status;
        }

        /// Método para obter quantidade de pessoas
        public int obterQuantidade()
        {
            return qntPessoas;
        }

        /// Método para obter uma mesa
        public Mesa obterMesa()
        {
            return mesa;
        }

        /// Método para registrar saída do cliente
        public void registrarSaida()
        {
            dataSaida = DateTime.Now;
        }

        /// Método para alternar o status da mesa
        public void alternarStatus()
        {
            status = !status;
        }

        /// Método para adicionar nova comida no pedido
        public void updatePedido(Comida comida)
        {
            pedido.addComida(comida);
        }

        /// Método para fechar o pedido do cliente
        public string fecharPedido()
        {
            registrarSaida();
            obterMesa().alternarStatus(false);
            return pedido.relatorio() + "\nData Entrada: " + dataEntrada + "\nData Saída:" + dataSaida;
        }
    }
}
