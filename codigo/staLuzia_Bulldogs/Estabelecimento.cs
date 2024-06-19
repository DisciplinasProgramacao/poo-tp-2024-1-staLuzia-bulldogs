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
        protected Cardapio cardapio;
        protected List<Mesa> listaMesa;

        public Estabelecimento(){
            baseClientes = new Dictionary<string, Cliente>();
            baseRequisicao = new Dictionary<string, Requisicao>();
            cardapio = new Cardapio();
            listaMesa = new List<Mesa>();
        }

        public void addCliente(string nomeCliente){
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

        public abstract Comida selecionarProduto(int resp);

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