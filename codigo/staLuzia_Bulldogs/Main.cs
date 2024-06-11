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
        static Restaurante objRestaurante = new Restaurante();

        static void pausa()
        {
            Console.Write("\nTecle Enter para continuar.");
            Console.ReadLine();
        }

        static void cabecalho()
        {
            //Console.Clear();
            Console.WriteLine("====== Restaurante Sesas ======");
        }
        static bool novaTentativa(string contexto)
        {
            Console.WriteLine(contexto + ", insira informações válidas");
            Console.Write("Deseja tentar novamente? (S/N)");
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
                Console.WriteLine("Resposta inválida, favor tente novamente (aperte qualquer tecla para continuar)");
                return novaTentativa(contexto);
            }
        }

        static int menuPrincipal()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("===============================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Cadastrar cliente \n2) Requisitar mesa");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("3) Abrir Pedido \n4) Fechar Atendimento");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("5) Sair");
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

        static bool addComida(int resp, int qnt, Requisicao requisicao)
        {
            switch (resp)
            {
                case 1:
                    requisicao.updatePedido("Moqueca de Palmito", 32, qnt);
                    break;
                case 2:
                    requisicao.updatePedido("Falafel Assado", 20, qnt);
                    break;
                case 3:
                    requisicao.updatePedido("Salada Primavera com Macarrão Konjac", 32, qnt);
                    break;
                case 4:
                    requisicao.updatePedido("Escondidinho de Inhame", 32, qnt);
                    break;
                case 5:
                    requisicao.updatePedido("Strogonoff de Cogumelos", 32, qnt);
                    break;
                case 6:
                    requisicao.updatePedido("Caçarola de legumes", 32, qnt);
                    break;
                case 7:
                    requisicao.updatePedido("Água", 3, qnt);
                    break;
                case 8:
                    requisicao.updatePedido("Copo de suco", 7, qnt);
                    break;
                case 9:
                    requisicao.updatePedido("Refrigerante orgânico", 7, qnt);
                    break;
                case 10:
                    requisicao.updatePedido("Cerveja vegana", 9, qnt);
                    break;
                case 11:
                    requisicao.updatePedido("Taça de vinho vegano", 18, qnt);
                    break;
                case 12:
                    return false;
            }
            return true;
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

        static Mesa requisitarMesa(int qntPessoas)
        {
            Mesa mesa;
            mesa = objRestaurante.mesaDisponivel(qntPessoas);
            if (mesa == null)
            {
                //add fila espera
                return null!;
            }
            return mesa;
        }

        static void criarCliente()
        {
            string nomeCliente;
            cabecalho();
            Console.WriteLine("-------Cadastro-------");
            Console.Write("Qual o nome do cliente: ");
            nomeCliente = Console.ReadLine()!;
            if (isNumeric(nomeCliente))
            {
                throw new FormatException("Nome inválido");
            }

            objRestaurante.addCliente(nomeCliente);
            Console.WriteLine("Cadastro realizado com sucesso");
            pausa();
        }

        static void criarRequisicao()
        {
            int qntPessoas;
            Cliente cliente;
            Mesa mesa;
            cabecalho();
            Console.WriteLine("-------Requisitar-Mesa-------");
            Console.Write("Qual cliente será atendido?");
            cliente = objRestaurante.localizarCliente(Console.ReadLine()!);
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não achado");
            }
            Console.Write("Qual a quantidade de pessoas que pessoas que serão atendidas?");
            qntPessoas = int.Parse(Console.ReadLine()!); //FormatException
            if (qntPessoas < 0)
            {
                throw new ArgumentOutOfRangeException("Valor negativo é inválido nesse contexto");
            }
            mesa = requisitarMesa(qntPessoas);
            objRestaurante.abrirRequisicao(qntPessoas, mesa);
            Console.WriteLine("Requisição criada com sucesso");
            pausa();
        }

        static void abrirPedido()
        {
            Requisicao requisicao;
            int qntProdutos;
            int respPedido;
            cabecalho();
            Console.WriteLine("-------Abrir-Pedido-------");
            Console.Write("Qual cliente fará um pedido?");
            requisicao = objRestaurante.localizarRequisição(Console.ReadLine()!);
            if (requisicao == null)
            {
                throw new ArgumentNullException("Nome inválido, insira informações válidas");
            }

            respPedido = menuComidas();
            Console.WriteLine("Quantos desse produto?");
            int.TryParse(Console.ReadLine()!, out qntProdutos); //Format Exception

            if (qntProdutos < 0)
            {
                throw new ArgumentOutOfRangeException("Valor negativo é inválido nesse contexto");
            }
            addComida(respPedido, qntProdutos, requisicao);

            Console.WriteLine("Pedido realizado com sucesso");
            pausa();
        }

        static void fecharAtendimento()
        {
            Requisicao requisicao;
            string nomeCliente;
            cabecalho();
            Console.WriteLine("-------Fechar-Atendimento-------");
            Console.Write("Qual cliente fechará o pedido?");
            nomeCliente = Console.ReadLine()!;
            requisicao = objRestaurante.localizarRequisição(nomeCliente);
            if (requisicao == null)
            {
                throw new ArgumentNullException("Nome inválido, insira informações válidas");
            }
            string result = objRestaurante.encerrarAtendimento(requisicao, nomeCliente);
            Console.WriteLine(result);
            Console.WriteLine("Atendimento fechado com sucesso");
            pausa();
        }

        static void Main(string[] args)
        {
            bool cond = true;
            int opcaoMenu;

            do
            {
                opcaoMenu = menuPrincipal();

                switch (opcaoMenu)
                {
                    case 1:
                        try
                        {
                            criarCliente();
                        }
                        catch (FormatException ex)
                        {
                            if (novaTentativa(ex.Message.ToString()))
                                criarCliente();
                        }
                        break;

                    case 2:
                        bool tentativa = false;

                        try
                        {
                            criarRequisicao();
                        }
                        catch (ArgumentNullException an)
                        {
                            tentativa = novaTentativa(an.Message.ToString());
                        }
                        catch (FormatException)
                        {
                            tentativa = novaTentativa("Quantidade de pessoas inválida");
                        }
                        catch (ArgumentOutOfRangeException ao)
                        {
                            tentativa = novaTentativa(ao.Message.ToString());
                        }
                        finally
                        {
                            if (tentativa)
                                criarRequisicao();
                        }
                        break;

                    case 3:
                        tentativa = false;

                        try
                        {
                            abrirPedido();
                        }
                        catch (ArgumentNullException an)
                        {
                            tentativa = novaTentativa(an.Message.ToString());
                        }
                        catch (FormatException)
                        {
                            tentativa = novaTentativa("Quantidade de produtos inválido");
                        }
                        catch (ArgumentOutOfRangeException ao)
                        {
                            tentativa = novaTentativa(ao.Message.ToString());
                        }
                        finally
                        {
                            if (tentativa)
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
                            if (novaTentativa(an.Message.ToString()))
                                fecharAtendimento();
                        }
                        break;

                    case 5:
                        cond = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, favor tentar novamente");
                        break;
                }
            } while (cond == true);
        }
    }
}
