using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace staLuzia_Bulldogs
{
    internal class Program
    {
        static Estabelecimento objEstabelecimento = null!;

        /// Início
        static void pausa()
        {
            Console.Write("\nTecle Enter para continuar.");
            Console.ReadLine();
        }

        /// Nome do sistema
        static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("========== Sese's System ==========");
        }

        /// Aviso se der algum erro
        static void avisoErro(string contexto)
        {
            Console.WriteLine($"\n## {contexto}, insira informações validas ##");
            Console.WriteLine("(Aperte qualquer tecla para continuar)");
            Console.ReadKey();
        }

        /// Nova tentativa para acessar menu
        static bool novaTentativa(string contexto)
        {
            Console.WriteLine($"\n{contexto} (S/N)");
            Console.Write("RESPOSTA: ");
            return Console.ReadLine()!.ToLower() == "s" ? true : false;
        }

        /// Verificar se resposta é numérica 
        static bool isNumeric(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsNumber(value[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// Menu principal restaurante
        static int menuPrincipalRest()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("===============================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Cadastrar cliente \n2) Abrir Requisicao");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("3) Abrir Pedido \n4) Fechar Atendimento");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("5) Sair");
            Console.WriteLine("===============================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
        }

        /// Menu principal cafeteria
        static int menuPrincipalCafe()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("===============================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Abrir Requisicao");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("2) Abrir Pedido \n3) Fechar Atendimento");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("4) Sair");
            Console.WriteLine("===============================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
        }


        /// Cadastrar novo cliente
        static void criarCliente()
        {
            try
            {
                string nomeCliente;
                cabecalho();
                Console.WriteLine("-------Cadastro-------");
                Console.WriteLine("Qual o nome do cliente: ");
                Console.Write("RESPOSTA: ");
                nomeCliente = Console.ReadLine()!;
                if (isNumeric(nomeCliente))
                {
                    throw new FormatException("Nome inválido");
                }

                objEstabelecimento.addCliente(nomeCliente);
                Console.WriteLine("\nCadastro realizado com sucesso");
                pausa();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Cliente já foi criado com esse nome");
            }
        }

        /// Criar nova requisição
        static void criarRequisicaoRest()
        {
            int qntPessoas;
            Cliente cliente;
            cabecalho();
            Console.WriteLine("-------Abrir-Requisicao-------");
            Console.WriteLine("Qual cliente será atendido?");
            Console.Write("RESPOSTA: ");

            cliente = objEstabelecimento.localizarCliente(Console.ReadLine()!);
            Console.WriteLine("\nQual a quantidade de pessoas que serão atendidas?");
            Console.Write("RESPOSTA: ");

            qntPessoas = int.Parse(Console.ReadLine()!); //FormatException
            if (qntPessoas < 0)
                throw new ValorInvalidoException("Valor negativo é inválido nesse contexto");

            if (objEstabelecimento.abrirRequisicao(qntPessoas, cliente) != null)
                Console.WriteLine("Requisição criada com sucesso");
            pausa();
        }

        /// Método para abrir pedido
        static void abrirPedido()
        {
            Requisicao requisicao;
            cabecalho();
            Console.WriteLine("-------Abrir-Pedido-------");
            Console.WriteLine("Qual cliente fará o pedido?");
            Console.Write("RESPOSTA: ");
            requisicao = objEstabelecimento.localizarRequisicao(Console.ReadLine()!);
            if (inserirEmPedido(requisicao))
                Console.WriteLine("\nPedido realizado com sucesso!");
            else { Console.WriteLine("\nPedido CANCELADO com sucesso!"); }
            pausa();
        }

        /// Método para adicionar comidas no pedido
        static bool inserirEmPedido(Requisicao requisicao)
        {
            int qntProdutos;
            int respPedido;
            bool cond = false;
            while (cond == false)
            {
                try
                {
                    respPedido = escolherComida();
                    if (respPedido == 0)
                        return false;
                    Console.WriteLine("\nQuantos desse produto?");
                    Console.Write("RESPOSTA: ");
                    int.TryParse(Console.ReadLine()!, out qntProdutos); //Format Exception

                    if (qntProdutos < 0)
                    {
                        throw new ValorInvalidoException("Valor negativo é inválido nesse contexto");
                    }

                    for (int i = 0; i < qntProdutos; i++)
                    {
                        objEstabelecimento.addComida(respPedido, requisicao);
                    }

                    Console.WriteLine("\nItem adicionado ao pedido!");
                    cond = !novaTentativa("Deseja adcionar mais comidas?");
                }
                catch (Exception ex)
                {
                    avisoErro(ex.Message);
                }
            }
            return true;
        }

        /// Método para escolher comida do menu
        static int escolherComida()
        {

            int opcaoMenu;
            cabecalho();
            Console.WriteLine(objEstabelecimento.exibirMenu());
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            if (opcaoMenu <= 0 || opcaoMenu > objEstabelecimento.tamanhoMenu())
            {
                throw new ValorInvalidoException("Opção do menu inválido!");
            }
            if (opcaoMenu == objEstabelecimento.tamanhoMenu())
                return 0;
            return opcaoMenu;
        }

        /// Fechar atendimento
        static void fecharAtendimento()
        {
            Cliente cliente;
            cabecalho();
            Console.WriteLine("-------Fechar-Atendimento-------");
            Console.WriteLine("Qual cliente fechará o pedido?");
            Console.Write("RESPOSTA: ");
            cliente = objEstabelecimento.localizarCliente(Console.ReadLine()!);
            Requisicao eliminada = objEstabelecimento.encerrarAtendimento(cliente);
            Console.WriteLine(eliminada.resumoPedido());
            
            pausa();
        }

        /// Determinar o tipo do estabelecimento
        static void mainEstabelecimentos(int tipo)
        {
            if (tipo == 1)
                objEstabelecimento = new Restaurante();
            else if (tipo == 2)
                objEstabelecimento = new Cafeteria();

            bool cond = true;
            int opcaoMenu;

            do
            {
                opcaoMenu = menuPrincipalRest();

                switch (opcaoMenu)
                {
                    case 1:
                        try
                        {
                            criarCliente();
                        }
                        catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
                        {
                            avisoErro(ex.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            criarRequisicaoRest();
                        }
                        catch (Exception ex) when (ex is FormatException || ex is ValorInvalidoException || ex is KeyNotFoundException || ex is ArgumentException)
                        {
                            avisoErro(ex.Message);
                        }
                        catch (InvalidOperationException io)
                        {
                            Console.WriteLine(io.Message);
                            Console.WriteLine("(Aperte qualquer tecla para continuar)");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        try
                        {
                            abrirPedido();
                        }
                        catch (Exception ex) when (ex is FormatException || ex is ValorInvalidoException || ex is KeyNotFoundException)
                        {
                            avisoErro(ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            fecharAtendimento();
                        }
                        catch (KeyNotFoundException kn)
                        {
                            avisoErro(kn.Message);

                        }
                        break;

                    case 5:
                        cond = false;
                        break;

                    default:
                        avisoErro("Opção inválida");
                        break;
                }
            } while (cond == true);
        }

        static void Main(string[] args)
        {
            int opcaoMenu;

            try
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao Sesa's System");
                Console.WriteLine("===========================");
                Console.WriteLine("Qual estabelecimento será usado?");
                Console.WriteLine("1) Restaurante\n2) Cafeteria");
                Console.WriteLine("===========================");
                Console.Write("Resposta: ");
                opcaoMenu = int.Parse(Console.ReadLine()!);
                if (opcaoMenu < 1 || opcaoMenu > 2)
                    throw new FormatException();
                mainEstabelecimentos(opcaoMenu);
            }
            catch (FormatException)
            {
                avisoErro("Estabelecimento inválido");
                Console.ReadKey();
                Main(args);
            }
        }
    }
}
