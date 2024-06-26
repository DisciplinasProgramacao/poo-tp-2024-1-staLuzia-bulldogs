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
    public override Requisicao abrirRequisicao(int qntPessoas, Cliente cliente)
        {
            try
            {
                Requisicao requisicao = new Requisicao(qntPessoas, cliente);
                baseRequisicao.Add(cliente.ToString(), requisicao);
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

    /// Método para encerrar o atendimento de um cliente
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
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException($"O cliente {requisicao.ToString()} acaba de sair da fila de espera e abre uma requisição!");
            }
        }

}
