using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex17
{

    class Program
    {
        static void carregaVetor(double[] vet)
        {
            double num;

            for(int i=0; i< vet.Length;i++)
            {
                while (!checkDouble("Informe o numero: ",out num)) ;

                vet[i] = num;
            }
            

        }

        static void listaVetor(double[] vet) 
        {

            if (vet.Length == 0)
            {
                Console.WriteLine("Erro: Vetor nao atribuido");
                Console.Read();
                return;
            }


            Console.WriteLine("Numeros no vetor:");

            for (int i = 0; i < vet.Length; i++) {
                Console.WriteLine(i + ": "+ vet[i]);
            }
        }

        static void listaPares(double[] vet)
        {

            if (vet.Length == 0)
            {
                Console.WriteLine("Erro: Vetor nao atribuido");
                return;
            }


            Console.WriteLine("Numeros pares no vetor:");
            for (int i = 0; i < vet.Length; i++)
            {
                if(vet[i]%2==0)
                {
                    Console.WriteLine(vet[i]);
                }
            }
        }

        static void listaImpares(double[] vet)
        {

            if (vet.Length == 0)
            {
                Console.WriteLine("Erro: Vetor nao atribuido");
                return;
            }


            Console.WriteLine("Numeros impares no vetor:");
            for (int i = 0; i < vet.Length; i++)
            {
                if (vet[i] % 2 != 0)
                {
                    Console.WriteLine(vet[i]);
                }
            }
        }

        static void contaPares(double[] vet)
        {
            int pares = 0;

            if(vet.Length == 0)
            {
                Console.WriteLine("Erro: Vetor nao atribuido");
                return;
            }

            for (int i = 0; i < vet.Length; i++)
            {
                if (vet[i] % 2 == 0 && i % 2 == 0)
                {
                    pares++; 
                }
            }

            Console.WriteLine("Quantidade de pares em posições pares: "+pares);
        }

        static void contaImpares(double[] vet)
        {

            if (vet.Length == 0)
            {
                Console.WriteLine("Erro: Vetor nao atribuido");
                return;
            }


            int impares = 0;

            for (int i = 0; i < vet.Length; i++)
            {
                if (vet[i] % 2 != 0 && i % 2 != 0)
                {
                    impares++;
                }
            }

            Console.WriteLine("Quantidade de impares em posições impares: " + impares);
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

        static bool checkInt(out int value)
        {

            string input = Console.ReadLine();

            if (Int32.TryParse(input, out value))
            {
                return true;
            }
            Console.WriteLine("Erro: tipo invalido");
            return false;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("1.Carregar Vetor\n2.Listar Vetor\n3.Exibir numeros pares do vetor\n4.Exibir numeros impares do vetor\n5.Exibir quantidade de pares em posicoes pares no vetor\n6.Exibir quantidade de impares em posicoes impares no vetor\n7.Sair");

            int input;
            double[] vet = null;

            do
            {

                Console.WriteLine("Digite o valor da operação: ");
                checkInt(out input);

                switch (input)
                {
                    case 1:
                        int tam;
                        Console.WriteLine("Informe o tamanho do vetor: ");
                        while (!checkInt(out tam)) ;

                        vet = new double[tam];

                        carregaVetor(vet);
                        break;
                    case 2:
                        listaVetor(vet);
                        break;
                    case 3:
                        listaPares(vet);
                        break;
                    case 4:
                        listaImpares(vet);
                        break;
                    case 5:
                        contaPares(vet);
                        break;
                    case 6:
                        contaImpares(vet);
                        break;
                    case 7:
                        return;
                }

            }while (input != 7);
        }
    }
}
