using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;


namespace staLuzia_Bulldogs
{
    internal class Estabelecimento
    {
        private Dictionary<string, Cliente> baseClientes;
        private Dictionary<string, Requisicao> baseRequisicao;
        private List<Mesa> listaMesa;

        public void addCliente(string nomeCliente){
            Cliente novo = new Cliente(nomeCliente);
            baseClientes.Add(nomeCliente, novo);
        }
        public abstract bool atribuirRequisicao(Requisicao nova);

        public Requisicao abrirRequisicao(int quantidadePessoas, Mesa mesa)
        {
            Requisicao requisicao = new Requisicao(quantidadePessoas, mesa);
            return requisicao;
        }
        public string encerrarAtendimento(Requisicao requisicao, string nomeCliente)
        {
            if (requisicao.verificarStatus())
            {
                requisicao.registrarSaida();
                requisicao.obterMesa().alternarStatus(false);
                baseRequisicao.Remove(nomeCliente);
                avancarFila();
                return requisicao.fecharPedido();
            }
            return "Requisição já fechada";
        }
    }
}