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

        static int menuPrincipal()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("=============================================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Cadastrar cliente \n2) Requisitar mesa");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("3) Realizar Pedido \n4) Fechar Pedido");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("5) Sair");
            Console.WriteLine("=============================================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
        }

        static int menuBebidas()
        {
            int opcaoMenu;
            cabecalho();
            Console.WriteLine("===================Bebidas====================");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1. Água – R$ 3");
            Console.WriteLine("2. Copo de suco – R$ 7");
            Console.WriteLine("3. Refrigerante orgânico – R$ 7");
            Console.WriteLine("4. Cerveja vegana – R$ 9");
            Console.WriteLine("5. Taça de vinho vegano – R$ 18");
            Console.WriteLine("\n=============================================");
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
            Console.WriteLine("\n=============================================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
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
            if(mesa == null){
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
                            tentativa("Cadastro inválido, insira informações válidas"); //Se não quiser tentar novamente, sair da função
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
                        Console.WriteLine("-------Requisição-------");
                        Console.Write("Qual cliente será atendido?");
                        //nomeCliente = Console.ReadLine()!;
                        cliente = objRestaurante.localizarCliente(Console.ReadLine()!);
                        Console.Write("Qual a quantidade de pessoas que pessoas que serão atendidas?");
                        qntPessoas = Console.ReadLine()!;

                        if (String.IsNullOrEmpty(qntPessoas) || int.TryParse(qntPessoas, out intQntPessoas) || cliente == null)
                            tentativa("Cadastro inválido, insira informações válidas");
                        else
                        {
                            mesa = requisitarMesa(intQntPessoas);
                            objRestaurante.abrirRequisicao(cliente, intQntPessoas, mesa);
                            Console.WriteLine("Requisição criada com sucesso");
                            pausa();
                        }
                        break;

                    case 3:
                        Console.WriteLine("-------Abrir-Pedido-------");
                        break;

                    case 4:
                        cond = false;
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
