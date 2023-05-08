using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste2
{
    class Program
    {

        static bool checkInput(string input) {

            if (double.TryParse(input, out _))
            {
                return true;
            }

            else if (int.TryParse(input, out _))
            {
                return true;
            }
            else {
                return false;
            }
        }

        static void Main(string[] args)
        {

            string leitura;

            do {

                Console.WriteLine("Informe a cotacao do dolar: ");

                leitura = Console.ReadLine();

                if (!checkInput(leitura)) {

                    Console.WriteLine("Erro: tipo invalido");

                }

            } while (!checkInput(leitura));

           
            leitura = leitura.Replace('.', ',');


            double cotacao = Convert.ToDouble(leitura);

            do
            {

                Console.WriteLine("\nInforme um valor em reais");

                leitura = Console.ReadLine();

                if (!checkInput(leitura))
                {
                    Console.WriteLine("Erro: Tipo invalido");
                }

            } while (!checkInput(leitura));


            leitura = leitura.Replace('.', ',');


            double valorReais = Convert.ToDouble(leitura);

            double valorConvertido = valorReais * cotacao;

            Console.WriteLine("\nO valor convertido e: " + valorConvertido);

            Console.Read();

        }
    }
}
