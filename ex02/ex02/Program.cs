using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    class Program
    {
        static bool checkInput(string input)
        {

            if (double.TryParse(input, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string leitura;

            do
            {
                Console.WriteLine("Informe uma temperatura em C°");
                leitura = Console.ReadLine();

                if (!checkInput(leitura))
                {
                    Console.WriteLine("\nErro: Tipo invalido\n");
                }

            } while (!checkInput(leitura));

            leitura = leitura.Replace('.', ',');
            double temperaturaC = Convert.ToDouble(leitura);

            double temperaturaF = (9 * temperaturaC + 160) / 5;

            Console.WriteLine("\nA temperatura em F° e:  " + temperaturaF);

            Console.Read();
        }
    }
}
