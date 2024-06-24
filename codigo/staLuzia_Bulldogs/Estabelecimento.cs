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
        protected List<Mesa> listaMesa;

        public Estabelecimento()
        {
            baseClientes = new Dictionary<string, Cliente>();
            baseRequisicao = new Dictionary<string, Requisicao>();
            listaMesa = new List<Mesa>();
        }

        public void addCliente(string nomeCliente)
        {
            Cliente novo = new Cliente(nomeCliente);
            baseClientes.Add(nomeCliente, novo);
        }

        public abstract Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente);

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

        public string exibirMenu()
        {
            return cardapio.ToString();
        }

        public int tamanhoMenu()
        {
            return cardapio.tamanho();
        }

        public void addComida(int resp, Requisicao requisicao)
        {
            try {
                Comida comida = selecionarProduto(resp);
                requisicao.updatePedido(comida);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Cliente não possui requisição");
            }
        }

        public Comida selecionarProduto(int resp)
        {
            return cardapio.produto(resp);
        }

        public string encerrarAtendimento(Cliente cliente)
        {
            try
            {
                Requisicao requisicao = baseRequisicao[cliente.ToString()];

                if (!requisicao.verificarStatus())
                {
                    baseRequisicao.Remove(cliente.ToString());
                    return requisicao.fecharPedido();
                }
                return "Requisição já fechada";
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Cliente não possui requisição");
            }
        }
    }
}