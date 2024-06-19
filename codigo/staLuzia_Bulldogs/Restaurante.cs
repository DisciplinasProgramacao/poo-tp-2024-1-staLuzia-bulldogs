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

        public override Comida selecionarProduto(int resp){
            return cardapio.produtoRestaurante(resp);
        }

        public Cliente localizarCliente(string nomeCliente)
        {
            if (baseClientes.ContainsKey(nomeCliente))
                return baseClientes[nomeCliente];
            return null!;
        }

        public Requisicao localizarRequisição(string nomeCliente)
        {
            if (baseRequisicao.ContainsKey(nomeCliente))
                return baseRequisicao[nomeCliente];
            return null!;
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
