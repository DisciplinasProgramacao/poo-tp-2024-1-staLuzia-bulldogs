using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    class Restaurante : Estabelecimento
    {
        private Queue<Requisicao> filaEspera;
        private List<Mesa> listaMesa;
        static int MAX_ASSENTOS;


        /// Criar novo cardápio e atribuir as mesas de um novo restaurante
        public Restaurante()
        {
            cardapio = new CardapioRest();
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
            MAX_ASSENTOS = 8;
            filaEspera = new Queue<Requisicao>();
        }

        /// Método para abrir requisição no restaurante
        public override Requisicao abrirRequisicao(int qntPessoas, Cliente cliente)
        {
            try
            {
                if (qntPessoas > MAX_ASSENTOS)
                    throw new ValorInvalidoException("Não possuimos mesa para essa quantidade de pessoas");
                Requisicao requisicao = new Requisicao(qntPessoas, cliente);
                baseRequisicao.Add(cliente.ToString(), requisicao);
                alocarMesa(requisicao);
                return requisicao;
            }
            catch (ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
                return null!;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("O cliente já possui uma requisição aberta");
            }
        }

        private void alocarMesa(Requisicao requisicao)
        {
            Mesa mesaIdeal = listaMesa.Where(m => m.verificarDisponibilidade(requisicao.obterQuantidade())).FirstOrDefault()!;;
            if (mesaIdeal == null)
            {
                filaEspera.Enqueue(requisicao);
                throw new ArgumentNullException("Mesa não disponível para tal quantidade de pessoas, cliente será colocado na fila de espera!\n");
            }
            requisicao.ocuparMesa(mesaIdeal);
        }

        public override string encerrarAtendimento(Cliente cliente)
        {
            try
            {
                Requisicao requisicao = baseRequisicao[cliente.ToString()];
                baseRequisicao.Remove(cliente.ToString());
                requisicao.liberarMesa();
                avancarFilaMesa();
                return requisicao.fecharPedido();
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Cliente não possui requisição");
            }
        }

        private void avancarFilaMesa()
        {
            if(filaEspera.Count != 0)
            {
                Requisicao requisicaoFila = filaEspera.Dequeue();
                alocarMesa(requisicaoFila);
                Console.WriteLine($"O Cliente {requisicaoFila.dono()} acaba de sair da fila de espera e ocupa uma mesa!");
            }

        }
    }
}
