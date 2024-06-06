using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Restaurante
    {
        private Dictionary<string, Cliente> baseClientes;
        private Mesa[] listaMesa;
        private Queue<Requisicao> filaEspera;
        public Restaurante()
        {
            baseClientes = new Dictionary<string, Cliente>();
            listaMesa = new Mesa[10];
            filaEspera = new Queue<Requisicao>();
        }

        public Cliente localizarCliente(string nomeCliente){
            if(baseClientes.ContainsKey(nomeCliente))
                return baseClientes[nomeCliente];
            return null!;
        }

        public void addCliente(string nomeCliente){
            Cliente novo = new Cliente(nomeCliente);
            baseClientes.Add(nomeCliente, novo);
        }
        public Requisicao abrirRequisicao(Cliente cliente, int quantidadePessoas, Mesa mesa)
        {
            Requisicao requisicao = new Requisicao(cliente, quantidadePessoas, mesa);
            requisicao.registrarEntrada(DateTime.Now);
            return requisicao;
        }
        // public bool avancarFila()
        // {
        //     if (filaEspera.Count != 0)
        //     {
        //         if (verificarDisponibilidade(filaEspera.Peek()))
        //         {
        //             atribuirRequisicao(filaEspera.Dequeue());      
        //         }
        //         return true;
        //     }
        //     return false;
        // }
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
        public bool encerrarAtendimento(Requisicao requisicao)
        {
            if (requisicao.verificarStatus())
            {
                requisicao.registrarSaida(DateTime.Now);
                requisicao.obterMesa().alternarStatus(false);
                //avançar fila
                return true;
            }
            return false;
        }
    }
}
