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

        static void pausa()
        {
            Console.WriteLine("(Aperte qualquer tecla para continuar)");
            Console.ReadLine();
        }

        static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("====== Restaurante Sesas ======");
        }
        static bool novaTentativa(string contexto)
        {
            Console.WriteLine($"\n## {contexto}, insira informações válidas ##");
            Console.WriteLine("\nDeseja tentar novamente? (S/N)");
            Console.Write("RESPOSTA: ");
            string resp = Console.ReadLine()!;
            if (resp == "n" || resp == "N")
            {
                return false;
            }
            else if (resp == "s" || resp == "S")
            {
                return true;
            }
            else
            {
                //Console.WriteLine("\nResposta inválida, favor tente novamente (aperte qualquer tecla para continuar)");
                return novaTentativa("Resposta inválida");
            }
        }

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

        static int menuComidas()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("===================Comidas===================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1. Moqueca de Palmito – R$ 32");
            Console.WriteLine("2. Falafel Assado – R$ 20");
            Console.WriteLine("3. Salada Primavera com Macarrão Konjac – R$ 25");
            Console.WriteLine("4. Escondidinho de Inhame – R$ 18");
            Console.WriteLine("5. Strogonoff de Cogumelos – R$ 35");
            Console.WriteLine("6. Caçarola de legumes – R$ 22");
            Console.WriteLine("\n===========================================");
            Console.WriteLine("===================Bebidas===================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("7. Água – R$ 3");
            Console.WriteLine("8. Copo de suco – R$ 7");
            Console.WriteLine("9. Refrigerante orgânico – R$ 7");
            Console.WriteLine("10. Cerveja vegana – R$ 9");
            Console.WriteLine("11. Taça de vinho vegano – R$ 18");
            Console.WriteLine("12. Cancelar");
            Console.WriteLine("\n===========================================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
        }

        static void addComida(int resp, int qnt, Requisicao requisicao)
        {
            Comida comida = objEstabelecimento.selecionarProduto(resp);
            requisicao.updatePedido(comida, qnt);
        }

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

        static void criarCliente()
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

        static void criarRequisicao()
        {
            int qntPessoas;
            Cliente cliente;
            cabecalho();
            Console.WriteLine("-------Abrir-Requisicao-------");
            Console.WriteLine("Qual cliente será atendido?");
            Console.Write("RESPOSTA: ");
            cliente = objEstabelecimento.localizarCliente(Console.ReadLine()!);
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não achado");
            }
            Console.WriteLine("\nQual a quantidade de pessoas que pessoas que serão atendidas?");
            Console.Write("RESPOSTA: ");
            qntPessoas = int.Parse(Console.ReadLine()!); //FormatException
            if (qntPessoas < 0)
            {
                throw new ArgumentOutOfRangeException("Valor negativo é inválido nesse contexto");
            }

            objEstabelecimento.abrirRequisicao(qntPessoas, cliente);
            Console.WriteLine("\nRequisição criada com sucesso");
            pausa();
        }

        static void abrirPedido()
        {
            Requisicao requisicao;
            int qntProdutos;
            int respPedido;
            cabecalho();
            Console.WriteLine("-------Abrir-Pedido-------");
            Console.WriteLine("Qual cliente fará um pedido?");
            Console.Write("RESPOSTA: ");
            requisicao = objEstabelecimento.localizarRequisição(Console.ReadLine()!);
            if (requisicao == null)
            {
                throw new ArgumentNullException("Nome inválido, insira informações válidas");
            }

            respPedido = menuComidas();
            Console.WriteLine("\nQuantos desse produto?");
            Console.Write("RESPOSTA: ");
            int.TryParse(Console.ReadLine()!, out qntProdutos); //Format Exception

            if (qntProdutos < 0)
            {
                throw new ArgumentOutOfRangeException("Valor negativo é inválido nesse contexto");
            }
            addComida(respPedido, qntProdutos, requisicao);

            Console.WriteLine("\nPedido realizado com sucesso");
            pausa();
        }

        static void mainRestaurante()
        {
            objEstabelecimento = new Restaurante();
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
                        catch (FormatException ex)
                        {
                            if (novaTentativa(ex.Message))
                                criarCliente();
                        }
                        break;

                    case 2:
                        try
                        {
                            criarRequisicao();
                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException || ex is ArgumentOutOfRangeException)
                        {

                            if (novaTentativa(ex.Message))
                                criarRequisicao();
                        }
                        break;

                    case 3:
                        try
                        {
                            abrirPedido();
                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException || ex is ArgumentOutOfRangeException)
                        {
                            if (novaTentativa(ex.Message))
                                criarRequisicao();
                        }
                        break;

                    case 4:
                        try
                        {
                            fecharAtendimento();
                        }
                        catch (ArgumentNullException an)
                        {
                            if (novaTentativa(an.Message))
                                fecharAtendimento();
                        }
                        break;

                    case 5:
                        cond = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, favor tentar novamente");
                        pausa();
                        break;
                }
            } while (cond == true);
        }

        static void mainCafeteria()
        {
            objEstabelecimento = new Restaurante();
            bool cond = true;
            int opcaoMenu;

            do
            {
                opcaoMenu = menuPrincipalCafe();

                switch (opcaoMenu)
                {
                    case 1:
                        try
                        {
                            criarRequisicao();
                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException || ex is ArgumentOutOfRangeException)
                        {

                            if (novaTentativa(ex.Message))
                                criarRequisicao();
                        }
                        break;

                    case 2:
                        try
                        {
                            abrirPedido();
                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException || ex is ArgumentOutOfRangeException)
                        {
                            if (novaTentativa(ex.Message))
                                abrirPedido();
                        }
                        break;

                    case 3:
                        try
                        {
                            fecharAtendimento();
                        }
                        catch (ArgumentNullException an)
                        {
                            if (novaTentativa(an.Message))
                                fecharAtendimento();
                        }
                        break;

                    case 4:
                        cond = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, favor tentar novamente");
                        break;
                }
            } while (cond == true);
        }

        static void fecharAtendimento()
        {
            Requisicao requisicao;
            string nomeCliente;
            cabecalho();
            Console.WriteLine("-------Fechar-Atendimento-------");
            Console.Write("Qual cliente fechará o pedido?");
            nomeCliente = Console.ReadLine()!;
            requisicao = objEstabelecimento.localizarRequisição(nomeCliente);
            if (requisicao == null)
            {
                throw new ArgumentNullException("Nome inválido, insira informações válidas");
            }
            string result = objEstabelecimento.encerrarAtendimento(requisicao, nomeCliente);
            Console.WriteLine(result);
            Console.WriteLine("Atendimento fechado com sucesso");
            pausa();
        }

        static void Main(string[] args)
        {
            int opcaoMenu = 0;

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
                if(opcaoMenu < 1 || opcaoMenu > 2)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                Console.WriteLine("Resposta inválida, favor tentar novamente");
                Console.ReadKey();
                Main(args);
            }

            if (opcaoMenu == 1)
            {
                mainRestaurante();
            }
            else if(opcaoMenu == 2){
                mainCafeteria();
            }
        }
    }
}
