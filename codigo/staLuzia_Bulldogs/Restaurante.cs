using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Restaurante : Estabelecimento
    {
        private Dictionary<string, Cliente> baseClientes;
        private Dictionary<string, Requisicao> baseRequisicao;
        private Mesa[] listaMesa;
        private Queue<Requisicao> filaEspera;
        public Restaurante()
        {
            baseClientes = new Dictionary<string, Cliente>();
            baseRequisicao = new Dictionary<string, Requisicao>();
            listaMesa = new Mesa[10];
            filaEspera = new Queue<Requisicao>();
        }

        public Cliente localizarCliente(string nomeCliente){
            if(baseClientes.ContainsKey(nomeCliente))
                return baseClientes[nomeCliente];
            return null!;
        }

        public Requisicao localizarRequisição(string nomeCliente){
            if(baseRequisicao.ContainsKey(nomeCliente))
                return baseRequisicao[nomeCliente];
            return null!;
        }

        public void addCliente(string nomeCliente){
            Cliente novo = new Cliente(nomeCliente);
            baseClientes.Add(nomeCliente, novo);
        }

        public Requisicao abrirRequisicao(int quantidadePessoas, Mesa mesa)
        {
            Requisicao requisicao = new Requisicao(quantidadePessoas, mesa);
            return requisicao;
        }
        public bool avancarFila()
        {
            if (filaEspera.Count != 0)
            {
                // if (verificarDisponibilidade(filaEspera.Peek()))
                // {
                //     atribuirRequisicao(filaEspera.Dequeue());      
                // }
                return true;
            }
            return false;
        }
        public Mesa mesaDisponivel(int qnt)
        {
            foreach (Mesa mesa in listaMesa)
            {
                if (mesa.verificarCapacidade(qnt) && !mesa.verificarDisponivel())
                {
                    return mesa;
                }
            }
            return null!;
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
