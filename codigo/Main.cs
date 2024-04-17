using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurante objRestaurante = new Restaurante();
            Program obj = new Program();

            Console.WriteLine("====== Bem vindo ao restaurante Sesas ======");
            Console.WriteLine("Esolha uma das opções a seguir: \n");
            Console.WriteLine("1) Cadastrar cliente \n2) Criar requisição \n3) Sair");
            Console.WriteLine("=============================================");
            Console.Write("Opção desejada: ");
            string opcaoMenu = Console.ReadLine();

            switch (opcaoMenu)
            {
                case "1":
                    while (obj.criarCliente() != true)
                    {
                        if (init("Cadastro inválido, insira informações válidas \n"))
                        {
                            Console.Clear();
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;

                case "2":
                    obj.criarRequisição();
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Opção inválida, favor tentar novamente");
                    Main(args);
                    break;
            }
        }

        private static bool init(string contexto)
        {
            Console.WriteLine(contexto);
            Console.Write("Deseja tentar novamente? (S/N)");
            string resp = Console.ReadLine();
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
                return init(contexto);
            }
        }

        public bool criarRequisição()
        {
            Requisição objRequisição;

            Console.WriteLine("-------Requisição-------");
            try
            {
                Console.Write("Qual a quantidade de pessoas que pessoas que serão atendidas?");
                string qntPessoas = Console.ReadLine();

                if (String.IsNullOrEmpty(qntPessoas))
                    return false;

                int intQntPessoas = Convert.ToInt32(qntPessoas);

                objRequisição = new Requisição(intQntPessoas);

                objRequisição.registrarEntrada(DateTime.Now);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool criarCliente()
        {
            Cliente objCliente;

            Console.WriteLine("-------Cadastro-------");
            try
            {
                Console.Write("Nome: ");
                string nomeCliente = Console.ReadLine();

                if (String.IsNullOrEmpty(nomeCliente) || isNumeric(nomeCliente))
                {
                    return false;
                }

                objCliente = new Cliente(nomeCliente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            Console.WriteLine("Cadastro realizado com sucesso");
            return true;
        }

        private bool isNumeric(string value)
        {
            for(int i = 0; i < value.Length; i++)
            {
                if (char.IsNumber(value[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
