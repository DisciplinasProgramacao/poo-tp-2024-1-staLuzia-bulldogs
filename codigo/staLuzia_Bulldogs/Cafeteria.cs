using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs;
class Cafeteria : Estabelecimento
{
    public Cafeteria(){
        cardapio = new Cardapio(ETipo.cafeteria);
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
}
