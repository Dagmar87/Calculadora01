using System;

namespace Calculadora
{
    class Calculadora
    {
        public static double DoOperacao(double num1, double num2, string op)
        {
            double resultado = double.NaN;

            switch (op)
            {
                case "a":
                    resultado = num1 + num2;
                    break;
                case "s":
                    resultado = num1 - num2;
                    break;
                case "m":
                    resultado = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        resultado = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return resultado;
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Calculadora de console em C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double resultado = 0;

                Console.WriteLine("Digite um número e pressione Enter");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while(!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor insira um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                Console.WriteLine("Digite um número e pressione Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor insira um valor inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Escolha uma opção na lista a seguir:");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
                Console.Write("Sua opção? ");

                string op = Console.ReadLine();

                try
                {
                    resultado = Calculadora.DoOperacao(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(resultado))
                    {
                        Console.WriteLine("Esta operação resultará em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", resultado);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Oh não! Ocorreu uma exceção ao tentar fazer as contas.\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Pressione 'n' e Enter para fechar o aplicativo ou pressione qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}

