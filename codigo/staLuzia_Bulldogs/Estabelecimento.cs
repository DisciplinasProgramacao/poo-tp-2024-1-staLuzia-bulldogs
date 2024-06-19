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
            listaMesa = new List<Mesa>();
        }
        public abstract Mesa alocarMesa(Requisicao nova);

        public Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente)
        {
            Requisicao requisicao = new Requisicao(quantidadePessoas, cliente);
            return requisicao;
        }

        public Requisicao localizarRequisição(string nomeCliente)
        {
            if (baseRequisicao.ContainsKey(nomeCliente))
                return baseRequisicao[nomeCliente];
            return null!;
        }

        public Comida selecionarProduto(int resp)
        {
            return cardapio.produto(resp);
        }

        public string encerrarAtendimento(Requisicao requisicao, string nomeCliente)
        {
            if (requisicao.verificarStatus())
            {
                requisicao.registrarSaida();
                requisicao.obterMesa().alternarStatus(false);
                baseRequisicao.Remove(nomeCliente);
                return requisicao.fecharPedido();
            }
            return "Requisição já fechada";
        }
    }
}