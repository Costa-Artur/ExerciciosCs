using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex04
{
    class Program
    {
        static bool checkDouble(string prompt, out double value)
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
            double tempo;
            while (!checkDouble("Informe o tempo da viagem em horas: ",out tempo)) ;

            double velocidade;
            while (!checkDouble("Informe a velocidade média da viagem: ", out velocidade)) ;

            double distancia = tempo * velocidade;

            double litrosUsados = distancia / 12;

            Console.WriteLine("Tempo gasto na viagem: " + tempo);
            Console.WriteLine("Distancia percorrida: " + distancia.ToString("F2"));
            Console.WriteLine("Velocidade media: " + velocidade);
            Console.WriteLine("Quantidade de litros gasta: " + litrosUsados.ToString("F2"));

            Console.Read();

        }
    }
}
