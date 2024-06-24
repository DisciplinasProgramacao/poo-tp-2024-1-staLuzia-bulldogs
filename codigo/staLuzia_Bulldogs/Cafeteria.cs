using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs;
class Cafeteria : Estabelecimento
{
    public Cafeteria()
    {
        cardapio = new Cardapio(ETipo.cafeteria);
    }

    public override Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente)
    {
            Requisicao requisicao = new Requisicao(quantidadePessoas, cliente);
        baseRequisicao.Add(cliente.ToString(), requisicao);
        requisicao.alternarStatus();
        return requisicao;
    }
    
}
