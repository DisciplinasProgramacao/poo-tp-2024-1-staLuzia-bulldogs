using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;


namespace staLuzia_Bulldogs
{
    internal abstract class Estabelecimento
    {
        protected Dictionary<string, Cliente> baseClientes;
        protected Dictionary<string, Requisicao> baseRequisicao;
        protected Cardapio cardapio = null!;

        /// <summary>
        /// Cria novo estabelecimento
        /// </summary>        
        public Estabelecimento()
        {
            baseClientes = new Dictionary<string, Cliente>();
            baseRequisicao = new Dictionary<string, Requisicao>();
        }

        /// Método para adicionar cliente
        public void addCliente(string nomeCliente)
        {
            Cliente novo = new Cliente(nomeCliente);
            baseClientes.Add(nomeCliente, novo);
        }

        /// Método para abrir requisição com a quantidade de pessoas e o nome do cliente
        public abstract Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente);

        /// Método para localizar cliente
        public Cliente localizarCliente(string nomeCliente)
        {
            try
            {
                return baseClientes[nomeCliente];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Cliente não achado");
            }
        }

        /// Método para localizar requisição cadastrada
        public Requisicao localizarRequisicao(string nomeCliente)
        {
            try
            {
                return baseRequisicao[nomeCliente];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Cliente não possui requisicao cadastrada");
            }
        }

        /// Método para mostrar o menu do estabelecimento
        public string exibirMenu()
        {
            return cardapio.ToString();
        }

        /// Método para ver a quantidade de opões no cardápio
        public int tamanhoMenu()
        {
            return cardapio.tamanho();
        }

        /// Método para adicionar comida no pedido
        public void addComida(int resp, Requisicao requisicao)
        {
            try
            {
                Comida comida = selecionarProduto(resp);
                requisicao.updatePedido(comida);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Cliente não possui requisição");
            }
        }

        /// Método para selecionar algum produto
        public Comida selecionarProduto(int resp)
        {
            return cardapio.produto(resp);
        }

        /// Método para encerrar o atendimento de um cliente
        public abstract Requisicao encerrarAtendimento(Cliente cliente);
    }
}