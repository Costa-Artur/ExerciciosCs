using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex17
{
    class Program
    {
        static double[] vetor;


        static void Main(string[] args)
        {

            double opcao;

            do
            {
                Console.WriteLine("1 - Carregar vetor");
                Console.WriteLine("2 - Listar vetor");
                Console.WriteLine("3 - Exibir apenas os números pares do vetor");
                Console.WriteLine("4 - Exibir apenas os números ímpares do vetor");
                Console.WriteLine("5 - Exibir a quantidade de números pares nas posições ímpares do vetor");
                Console.WriteLine("6 - Exibir a quantidade de números ímpares nas posições pares do vetor");
                Console.WriteLine("7 - Sair");

                while (!checkDouble("Escolha uma opção:", out opcao)) ;

                switch (opcao)
                {
                    case 1:
                        CarregarVetor();
                        break;

                    case 2:
                        ListarVetor();
                        break;

                    case 3:
                        ExibirPares();
                        break;

                    case 4:
                        ExibirImpares();
                        break;

                    case 5:
                        QtdParesPosicoesImpares();
                        break;

                    case 6:
                        QtdImparesPosicoesPares();
                        break;

                    case 7:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();

            } while (opcao != 7);
        } 

        static void CarregarVetor()
        {
            int tamanho;
            while (!checkInt("Digite o tamanho do vetor: ", out tamanho)) ;

            vetor = new double[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                while (!checkDouble("Informe um numero: ", out vetor[i])) ;
            }
        }

        static void ListarVetor()
        {
            if (vetor == null)
            {
                Console.WriteLine("Vetor não carregado!");
            }
            else
            {
                Console.WriteLine("Vetor:");

                for (int i = 0; i < vetor.Length; i++)
                {
                    Console.Write($"{vetor[i]} ");
                }

                Console.WriteLine();
            }
        }

        static void ExibirPares()
        {
            if (vetor == null)
            {
                Console.WriteLine("Vetor não carregado!");
            }
            else
            {
                Console.WriteLine("Números pares do vetor:");

                for (int i = 0; i < vetor.Length; i++)
                {
                    if (vetor[i] % 2 == 0)
                    {
                        Console.Write($"{vetor[i]} ");
                    }
                }

                Console.WriteLine();
            }
        }

        static void ExibirImpares()
        {
            if (vetor == null)
            {
                Console.WriteLine("Vetor não carregado!");
            }
            else
            {
                Console.WriteLine("Números ímpares do vetor:");

                for (int i = 0; i < vetor.Length; i++)
                {
                    if (vetor[i] % 2 != 0)
                    {
                        Console.Write($"{vetor[i]} ");
                    }
                }

                Console.WriteLine();
            }
        }

        static void QtdParesPosicoesImpares()
        {
            if (vetor == null)
            {
                Console.WriteLine("Vetor não carregado!");
            }
            else
            {
                int qtd = 0;

                for (int i = 1; i < vetor.Length; i += 2)
                {
                    if (vetor[i] % 2 == 0)
                    {
                        qtd++;
                    }
                }

                Console.WriteLine($"Quantidade de números pares nas posições ímpares do vetor: {qtd}");
            }
        }

        static void QtdImparesPosicoesPares()
        {
            if (vetor == null)
            {
                Console.WriteLine("Vetor não carregado!");
            }
            else
            {
                int qtd = 0;

                for (int i = 0; i < vetor.Length; i += 2)
                {
                    if (vetor[i] % 2 != 0)
                    {
                        qtd++;
                    }
                }

                Console.WriteLine($"Quantidade de números ímpares nas posições pares do vetor: {qtd}");
            }
        }

        static bool checkDouble(String prompt, out double value)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out value))
            {
                return true;
            }
            Console.WriteLine("Erro: tipo invalido");
            return false;

        }

        static bool checkInt(String prompt, out int value)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out value))
            {
                return true;
            }
            Console.WriteLine("Erro: tipo invalido");
            return false;

        }
    }
}