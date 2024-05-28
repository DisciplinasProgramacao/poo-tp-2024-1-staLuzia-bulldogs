using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class Program
    {
        static Dictionary<string, Cliente> baseClientes = new Dictionary<string, Cliente>();

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
            Console.Clear();
            int opcaoMenu;
            Console.WriteLine("====== Restaurante Sesas ======");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Cadastrar cliente \n2) Criar requisição \n3) Sair");
            Console.WriteLine("=============================================");
            Console.Write("Opção desejada: ");
            int.TryParse(Console.ReadLine(), out opcaoMenu);
            return opcaoMenu;
        }

        static Requisicao criarRequisição(Cliente cliente, int qntPessoas)
        {
            Requisicao objRequisição;
            try
            {
                objRequisição = new Requisicao(cliente, qntPessoas);

                objRequisição.registrarEntrada(DateTime.Now);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        static Cliente addCliente(string nomeCliente)
        {
            Cliente novo = new Cliente(nomeCliente);

            return novo;
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

        static void Main(string[] args)
        {
            Restaurante objRestaurante = new Restaurante();
            Program obj = new Program();
            string nomeCliente;
            string qntPessoas;
            int opcaoMenu;

            do
            {
                opcaoMenu = menuPrincipal();

                switch (opcaoMenu)
                {
                    case 1:
                        Cliente novo;
                        cabecalho();
                        Console.WriteLine("-------Cadastro-------");
                        Console.Write("Qual o nome do cliente: ");
                        nomeCliente = Console.ReadLine()!;
                        if (String.IsNullOrEmpty(nomeCliente) || isNumeric(nomeCliente))
                            tentativa("Cadastro inválido, insira informações válidas"); //Se não quiser tentar novamente, sair da função
                        else
                            novo = addCliente(nomeCliente);
                            baseClientes.Add(nomeCliente, novo);
                            Console.WriteLine("Cadastro realizado com sucesso");
                        pausa();
                        break;

                    case 2:
                        cabecalho();
                        Console.WriteLine("-------Requisição-------");
                        Console.Write("Qual cliente será atendido?");
                        nomeCliente = Console.ReadLine()!;
                        Console.Write("Qual a quantidade de pessoas que pessoas que serão atendidas?");
                        qntPessoas = Console.ReadLine()!;
                        int intQntPessoas;
                        if (String.IsNullOrEmpty(qntPessoas) || int.TryParse(qntPessoas, out intQntPessoas))
                            tentativa("Cadastro inválido, insira informações válidas");
                        else
                            criarRequisição(nomeCliente, qntPessoas);
                        break;

                    case 3:
                        break;

                    default:
                        Console.WriteLine("Opção inválida, favor tentar novamente");
                        break;
                }
            }
        }
    }
}
