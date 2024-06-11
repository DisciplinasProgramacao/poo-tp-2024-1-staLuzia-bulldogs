using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs;
class Cafeteria : Estabelecimento, throws ClienteJaPossuiMesaException
{
    public override bool atribuirRequisicao(Requisicao requisicao)
    {
        if (!requisicao.statusReserva())
        {
            int qntPessoas = requisicao.obterQuantidade();
            DateTime dataAgora = DateTime.Now;
            foreach (Mesa mesa in listaMesa)
            {
                if (mesa.verificarCapacidade(qntPessoas) && !mesa.verificarDisponivel())
                {
                    requisicao.reservar(mesa);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            throw new Exception ClienteJaPossuiMesaException("dfdasd");
        }
    }
}
