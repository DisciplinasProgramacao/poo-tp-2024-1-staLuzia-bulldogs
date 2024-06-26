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
                Requisicao requisicao = new Requisicao(qntPessoas, cliente);
                baseRequisicao.Add(cliente.ToString(), requisicao);
                return requisicao;
            }
            catch (ArgumentNullException)
            {
                return null!;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("O cliente já possui uma requisição aberta");
            }
        }

        public Requisicao alocarMesa(Requisicao requisicao)
        {
            if (requisicao.obterQuantidade() > MAX_ASSENTOS)
                throw new ValorInvalidoException("Não possuimos mesa para essa quantidade de pessoas");

            Mesa mesaIdeal = listaMesa.Where(m => m.verificarDisponibilidade(requisicao.obterQuantidade())).FirstOrDefault()!;
            if (mesaIdeal == null)
            {
                filaEspera.Enqueue(requisicao);
                return null!;
            }
            requisicao.ocuparMesa(mesaIdeal);
            return requisicao;
        }

        public override Requisicao encerrarAtendimento(Cliente cliente)
        {
            Requisicao requisicao = null!;
            try
            {
                requisicao = baseRequisicao[cliente.ToString()];
                baseRequisicao.Remove(cliente.ToString());
                return requisicao;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Cliente não possui requisição");
            }
        }

        public Requisicao avancarFilaMesa()
        {
            if (filaEspera.Count != 0)
            {
                Requisicao requisicaoFila = filaEspera.Dequeue();
                return alocarMesa(requisicaoFila);
            }
            return null!;
        }

        public override bool precisaMesa()
        {
            return true;
        }
    }
}
