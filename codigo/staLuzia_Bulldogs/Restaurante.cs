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

        public override Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente)
        {
            Requisicao requisicao = new Requisicao(quantidadePessoas, cliente);
            Mesa mesaIdeal = alocarMesa(requisicao);
            if (mesaIdeal == null)
            {
                addFilaEspera(cliente);
                throw new ArgumentNullException("Mesa não disponível para tal quantidade de pessoas, cliente será colocado na fila de espera");
            }
            baseRequisicao.Add(cliente.ToString(), requisicao);
            requisicao.ocuparMesa(mesaIdeal);
            requisicao.alternarStatus();
            return requisicao;
        }

        private Mesa alocarMesa(Requisicao requisicao)
        {
            try
            {
                return listaMesa.Where(m => m.disponibilidade()).Where(m => m.verificarCapacidade(requisicao.obterQuantidade())).FirstOrDefault()!;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Sem mesa disponível");
            }
        }


        private void addFilaEspera(Cliente cliente)
        {
            filaEspera.Enqueue(cliente);
        }
    }
}
