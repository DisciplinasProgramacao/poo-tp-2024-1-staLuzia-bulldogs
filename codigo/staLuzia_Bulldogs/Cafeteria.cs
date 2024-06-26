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
        cardapio = new CardapioCafe();
    }

    /// Abrir requisição para a quantidade de pessoas informadas
    public override Requisicao abrirRequisicao(int quantidadePessoas, Cliente cliente)
    {
        Requisicao requisicao = new Requisicao(quantidadePessoas, cliente);
        baseRequisicao.Add(cliente.ToString(), requisicao);
        return requisicao;
    }

    /// Método para encerrar o atendimento de um cliente
    public override string encerrarAtendimento(Cliente cliente)
    {
        try
        {
            Requisicao requisicao = baseRequisicao[cliente.ToString()];
            baseRequisicao.Remove(cliente.ToString());
            return requisicao.fecharPedido();
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException("Cliente não possui requisição");
        }
    }

}
