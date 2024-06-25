using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Restaurante : Estabelecimento
    {
        private Queue<Cliente> filaEspera;

        /// Criar novo cardápio e atribuir as mesas de um novo restaurante
        public Restaurante()
        {
            cardapio = new Cardapio(ETipo.restaurante);
            listaMesa = [
                new Mesa(4),
                new Mesa(4),
                new Mesa(4),
                new Mesa(4),
                new Mesa(6),
                new Mesa(6),
                new Mesa(6),
                new Mesa(6),
                new Mesa(8),
                new Mesa(8)
            ];
            filaEspera = new Queue<Cliente>();
        }

        /// Método para abrir requisição no restaurante
        public override Requisicao abrirRequisicao(int qntPessoas, Cliente cliente)
        {
            try
            {
                Requisicao requisicao = new Requisicao(qntPessoas, cliente);
                alocarMesa(requisicao);
                baseRequisicao.Add(cliente.ToString(), requisicao);
                return requisicao;
            }
            catch (ArgumentNullException)
            {
                filaEspera.Enqueue(cliente);
                throw new ArgumentNullException("Mesa não disponível para tal quantidade de pessoas, cliente será colocado na fila de espera");
            }
        }

        private void alocarMesa(Requisicao requisicao)
        {
            Mesa mesaIdeal = buscarMesa(requisicao.obterQuantidade());
            requisicao.ocuparMesa(mesaIdeal);
        }

        /// Método para alocar a mesa com a requisição feita
        private Mesa buscarMesa(int qntPessoas)
        {
            return listaMesa.Where(m => m.verificarCapacidade(qntPessoas)).Where(m => m.disponibilidade()).Single();
        }

        public override string encerrarAtendimento(Cliente cliente)
        {
            try
            {
                Requisicao requisicao = baseRequisicao[cliente.ToString()];
                avancarFilaMesa(requisicao.obterQuantidade());
                baseRequisicao.Remove(cliente.ToString());
                return requisicao.fecharPedido();
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Cliente não possui requisição");
            }
        }

        private void avancarFilaMesa(int qntPessoas)
        {
            if(filaEspera.Count != 0)
                abrirRequisicao(qntPessoas, filaEspera.Dequeue());
        }
    }
}
