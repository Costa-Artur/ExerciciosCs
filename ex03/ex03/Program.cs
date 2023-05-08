using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    class Program
    {
        static bool checkDouble (string prompt, out double value)
        {
            Console.WriteLine(prompt);

            string input = Console.ReadLine();
            input = input.Replace('.', ',');

            if (double.TryParse(input, out value))
            {
                return true;
            }
            Console.WriteLine("Erro: tipo invalido");
            return false;

        }

        static void Main(string[] args)
        {
            double peso;
            while (!checkDouble("Informe o peso: ", out peso));

            double altura;
            while (!checkDouble("Informe a altura: ", out altura)) ;

            double imc;

            imc = peso / Math.Pow(altura, 2);

            Console.WriteLine("Seu imc é: "+ imc.ToString("F2"));
            Console.Read();

        }
    }
}
