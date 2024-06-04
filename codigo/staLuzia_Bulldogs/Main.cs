using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class Program
    {
        static Restaurante objRestaurante = new Restaurante();

        static void pausa()
        {
            Console.Write("\nTecle Enter para continuar.");
            Console.ReadKey();
        }

        static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("====== Restaurante Sesas ======");
        }
        static bool tentativa(string contexto)
        {
            Console.WriteLine(contexto);
            Console.Write("Deseja tentar novamente? (S/N)");
            string resp = Console.ReadLine()!;
            if (resp.ToLower().Equals("n"))
            {
                return false;
            }
            else if (resp.ToLower().Equals("s"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Resposta inválida, favor tente novamente (aperte qualquer tecla para continuar)");
                Console.ReadKey();
                return tentativa(contexto);
            }
        }

        static bool novamente()
        {
            Console.Write("Deseja inserir novamente? (S/N)");
            string resp = Console.ReadLine()!;
            if (resp.ToLower().Equals("n"))
            {
                return false;
            }
            else if (resp.ToLower().Equals("s"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Resposta inválida, favor tente novamente (aperte qualquer tecla para continuar)");
                Console.ReadKey();
                return novamente();
            }
        }

        static int menuPrincipal()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("=============================================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Cadastrar cliente \n2) Requisitar mesa");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("3) Abrir Pedido \n4) Fechar Atendimento");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("5) Sair");
            Console.WriteLine("=============================================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
        }

        static int menuComida()
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
                case 9:
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

        static void Main(string[] args)
        {

            string nomeCliente;
            string qntPessoas;
            int opcaoMenu;
            bool cond = true;

            do
            {
                opcaoMenu = menuPrincipal();

                switch (opcaoMenu)
                {
                    case 1:
                        cabecalho();
                        Console.WriteLine("-------Cadastro-------");
                        Console.Write("Qual o nome do cliente: ");
                        nomeCliente = Console.ReadLine()!;
                        if (String.IsNullOrEmpty(nomeCliente) || isNumeric(nomeCliente))
                            tentativa("Cadastro inválido, insira informações válidas");
                        else
                        {
                            objRestaurante.addCliente(nomeCliente);
                            Console.WriteLine("Cadastro realizado com sucesso");
                            pausa();
                        }
                        break;

                    case 2:
                        int intQntPessoas;
                        Cliente cliente;
                        Mesa mesa;
                        cabecalho();
                        Console.WriteLine("-------Requisitar-Mesa-------");
                        Console.Write("Qual cliente será atendido?");
                        //nomeCliente = Console.ReadLine()!;
                        cliente = objRestaurante.localizarCliente(Console.ReadLine()!);
                        Console.Write("Qual a quantidade de pessoas que pessoas que serão atendidas?");
                        qntPessoas = Console.ReadLine()!;

                        if (String.IsNullOrEmpty(qntPessoas) || int.TryParse(qntPessoas, out intQntPessoas) || cliente == null)
                            tentativa("Requisição inválida, insira informações válidas");
                        else
                        {
                            mesa = requisitarMesa(intQntPessoas);
                            objRestaurante.abrirRequisicao(cliente, intQntPessoas, mesa);
                            Console.WriteLine("Requisição criada com sucesso");
                            pausa();
                        }
                        break;

                    case 3:
                        Requisicao requisicao;
                        cabecalho();
                        Console.WriteLine("-------Abrir-Pedido-------");
                        Console.Write("Qual cliente fará um pedido?");
                        //nomeCliente = Console.ReadLine()!;
                        requisicao = objRestaurante.localizarRequisição(Console.ReadLine()!);
                        if (String.IsNullOrEmpty(nomeCliente) || isNumeric(nomeCliente) || requisicao == null)
                            tentativa("Nome inválido, insira informações válidas");
                        else
                        {
                            bool cond2 = true;
                            int resp;
                            do
                            {
                                resp = menuComidas();
                                Console.WriteLine("Quantos desse produto?");
                                int.TryParse(Console.ReadLine()!, out qnt);
                                addComida(resp, qnt, requisicao);
                                
                                Console.Clear();
                                if(novamente() == false)
                                    cond2 = false;
                            } while (cond2 == true);
                            Console.WriteLine("Pedido realizado com sucesso");
                            pausa();
                        }
                        break;

                    case 4:
                        Console.WriteLine("-------Fechar-Atendimento-------");
                        Console.Write("Qual cliente fechará o pedido?");
                        nomeCliente = Console.ReadLine()!;
                        requisicao = objRestaurante.localizarRequisição(nomeCliente);
                        if (String.IsNullOrEmpty(nomeCliente) || isNumeric(nomeCliente) || requisicao == null)
                            tentativa("Nome inválido, insira informações válidas");
                        else
                        {
                            Console.WriteLine(objRestaurante.encerrarAtendimento(requisicao, nomeCliente));
                            Console.WriteLine("Atendimento fechado com sucesso");
                            pausa();
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
