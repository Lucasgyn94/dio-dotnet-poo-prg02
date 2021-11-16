using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoMenu = ObterOpcaoMenu();

            while (opcaoMenu.ToUpper() != "X")
            {

                switch (opcaoMenu)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        break;

                    default: throw new ArgumentOutOfRangeException();
                }
                opcaoMenu = ObterOpcaoMenu();
            }

            Console.WriteLine("Obrigado por utilizar os serviços da LF Bank, volte sempre!");
            Console.ReadLine();
        }

        public static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());

            ListContas[numeroConta].Depositar(valorDepositado);
        }

        public static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListContas[numeroConta].Sacar(valorSaque);

        }
        public static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferirdo: ");
            double valorTransferencia = int.Parse(Console.ReadLine());

            ListContas[indiceContaOrigem].Transferir(valorTransferencia, ListContas[indiceContaDestino]);

        }
        public static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < ListContas.Count; i++)
            {
                Conta conta = ListContas[i];
                Console.Write("# {0} ", i);
                Console.WriteLine(conta);
            }
        }
        public static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            ListContas.Add(novaConta);
        }

        private static string ObterOpcaoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("LF Bank a seu dispor!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar a Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoMenu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoMenu;
        }
    }
}
