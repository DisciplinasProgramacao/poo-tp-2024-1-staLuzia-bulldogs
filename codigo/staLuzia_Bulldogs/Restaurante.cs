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
            Mesa mesa;
            mesa = mesaDisponivel(quantidadePessoas);
            if (mesa == null)
            {
                addFilaEspera(cliente);
                throw new ArgumentNullException("Mesa não disponível para tal quantidade de pessoas, cliente será colocado na fila de espera");
            }
            Requisicao requisicao = new Requisicao(quantidadePessoas, cliente);
            requisicao.ocuparMesa(mesa);
            return requisicao;
        }



        public override Mesa alocarMesa(Requisicao requisicao)
        {
            try
            {
                return listaMesa.Where(m => m.verificarDisponivel()).Where(m => m.verificarCapacidade(requisicao.obterQuantidade())).FirstOrDefault()!;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Sem mesa disponível");
            }
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

        public void addFilaEspera(Cliente cliente)
        {
            filaEspera.Enqueue(cliente);
        }
    }
}
