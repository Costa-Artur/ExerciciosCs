using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace exercicioBancoDeDados
{
    class Program
    {

        static List<Cliente> clientes = new List<Cliente>();
        static string arquivoCSV = "clientes.csv";

        static bool checkInt(string prompt, out int value)
        {
            Console.Write(prompt + " ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out value))
            {
                return true;
            }
            Console.WriteLine("Erro: tipo inválido");
            return false;
        }

        static bool checkEmail(string email)
        {
            if (email.Contains('@'))
            {
                if (email.Contains('.'))
                {
                    return true;
                }
                Console.WriteLine("Email Invalido");
                return false;
            }
            Console.WriteLine("Email Invalido");
            return false;
        }

        static string pedirEmail(string prompt)
        {
            string email;
            do
            {
                Console.Write(prompt);
                email = Console.ReadLine();
            } while (!checkEmail(email));
            return email;
        }

        static void CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            if (clientes.Count > 0)
            {
                cliente.Id = clientes[clientes.Count - 1].Id + 1;
            }
            else
            {
                cliente.Id = 1;
            }

            Console.Write("Digite o nome do cliente: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Digite o endereço do cliente: ");
            cliente.Endereco = Console.ReadLine();

            Console.Write("Digite o telefone do cliente: ");
            cliente.Telefone = Console.ReadLine();

            cliente.Email = pedirEmail("Digite o e-mail do cliente: ");

            clientes.Add(cliente);
        }

        static void EditarCliente()
        {
            int id;
            while (!checkInt("Digite o ID do cliente a ser editado: ", out id)) ;

            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {

                Console.Write("Nome: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("Endereço: ");
                cliente.Endereco = Console.ReadLine();

                Console.Write("Telefone: ");
                cliente.Telefone = Console.ReadLine();

                cliente.Email = pedirEmail("Email: ");

            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        static void ExcluirCliente()
        {
            int id;
            while (!checkInt("Digite o ID do cliente a ser excluído: ", out id)) ;

            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        static void ListarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Não há clientes cadastrados.");
            }
            else
            {
                Console.WriteLine("Lista de clientes cadastrados:");
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"Id: {cliente.Id}");
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"Endereço: {cliente.Endereco}");
                    Console.WriteLine($"Telefone: {cliente.Telefone}");
                    Console.WriteLine($"E-mail: {cliente.Email}");
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        static void CarregarClientes()
        {
            if (File.Exists(arquivoCSV))
            {
                using (StreamReader sr = new StreamReader(arquivoCSV))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] dados = linha.Split(',');

                        Cliente cliente = new Cliente();
                        cliente.Id = int.Parse(dados[0]);
                        cliente.Nome = dados[1];
                        cliente.Endereco = dados[2];
                        cliente.Telefone = dados[3];
                        cliente.Email = dados[4];

                        clientes.Add(cliente);
                    }
                }
            }
        }

        static void SalvarClientes()
        {
            using (StreamWriter sw = new StreamWriter(arquivoCSV))
            {
                foreach (Cliente cliente in clientes)
                {
                    string linha = $"{cliente.Id},{cliente.Nome},{cliente.Endereco},{cliente.Telefone},{cliente.Email}";
                    sw.WriteLine(linha);
                }
            }
        }


        static void Main(string[] args)
        {
            CarregarClientes();

            int opcao = 0;
            while (opcao != 5)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Editar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Listar todos");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("----------------");

                while (!checkInt("Digite a opção desejada: ", out opcao)) ;
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        EditarCliente();
                        break;
                    case 3:
                        ExcluirCliente();
                        break;
                    case 4:
                        ListarClientes();
                        break;
                    case 5:
                        break;
                }

                Console.WriteLine();
            }

            SalvarClientes();
        }

    }
}
