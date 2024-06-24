using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs;
class Cafeteria : Estabelecimento
{
    /// Cria novo cardápio para a nova cafeteria
    public Cafeteria()
    {
        cardapio = new Cardapio(ETipo.cafeteria);
    }

    /// Abrir requisição para a quantidade de pessoas informadas
    public override Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente)
    {
        Requisicao requisicao = new Requisicao(quantidadePessoas, cliente);
        baseRequisicao.Add(cliente.ToString(), requisicao);
        requisicao.alternarStatus();
        return requisicao;
    }
    
}
