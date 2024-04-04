using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Restaurante
    {
       private List<Mesa> listaMesa;
       private Queue<Requisicao> filaRequisicao;
        public Restaurante(List<Mesa> listaMesa)
        {
            this.listaMesa = listaMesa;
            filaRequisicao = new Queue<Cliente>();
        }
        public bool atribuirRequisicao(Requisicao requisicao)
        {
            if (!requisicao.statusReserva())
            {
                int qntPessoas = requisicao.obterQuantidade();
                DateTime dataAgora = DateTime.Now;
                foreach(Mesa mesa in listaMesa)
                {
                    if(mesa.verificarCapacidade(qntPessoas) && !mesa.verificarDisponivel())
                    {
                        requisicao.reservar(mesa);
                        //requisicao.registrarEntrada(dataAgora);  Dúvida se registro de entrada é quando tem uma mesa, ou quando abre uma requisição
                        return true;
                    }
                }
                if(!filaRequisicao.Contains(requisicao))
                    filaRequisicao.Enqueue(requisicao);
                return false;

            }
        }
        public Requisicao abrirRequisicao(Cliente cliente, DateTime dataEntrada, int quantidadePessoas)
        {
            Requisicao requisicao = new Requisicao(cliente, quantidadePessoas);
            requisicao.registrarEntrada(dataEntrada);
            return requisicao;
        }
        public bool avancarFila()
        {
            if(filaRequisicao.Count != 0)
            {
                Requisicao requisicao = filaRequisicao.Peek();
                if (atribuirRequisicao(requisicao))
                    filaRequisicao.Dequeue();
                return true;
            }
            return false;
        }
        public string conferirStatusMesas()
        {
            StringBuilder status = new StringBuilder();
            foreach(Mesa mesa in listaMesa)
            {
                status.AppendLine(String.Format("Capacidade Mesa: {0}, Disponibilidade: {1}",mesa.obterCapacidade(), mesa.verificarDisponibilidade()));
            }
            return status.ToString();
        }
        public bool encerrarAtendimento(Requisicao requisicao){
            if (requisicao.verificarStatus())
            {
                requisicao.registrarSaida();
                requisicao.obterMesa().alternarStatus();
                requisicao.Mesa = null;
                return true;
            }
            return false;
        }
    }
}
