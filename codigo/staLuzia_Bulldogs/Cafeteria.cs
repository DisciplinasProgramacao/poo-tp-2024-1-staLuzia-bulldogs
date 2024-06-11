using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs{
    class Cafeteria : Restaurante{
        public bool override atribuirRequisicao(Requisicao requisicao)
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
            }
        }
    }
}