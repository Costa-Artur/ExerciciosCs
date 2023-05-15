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

        static bool checkEmail( string email) {
            if (email.Contains('@')) {
                
                return true;

            }
            Console.WriteLine("Email Invalido");
            return false;
        }

        static string pedirEmail(string prompt)
        {
            string email;
            do
            {
                Console.WriteLine(prompt);
                email = Console.ReadLine();
            } while (!checkEmail(email));
            return email;
        }

        static Cliente checkIdCliente (List<Cliente> clientes, int id) {
            foreach (Cliente cliente in clientes) {
                if (cliente.Id == id) {
                    return cliente;
                } 
            }
            return null;
        }

        static void Main(string[] args)
        {
            string arquivo = "clientes.csv";
            List<Cliente> clientes = new List<Cliente>();
            int ultimoID = 0;

            if (!File.Exists(arquivo))
            {
                using (StreamWriter sw = File.CreateText(arquivo))
                {
                }
            }

            if (File.Exists(arquivo)) {
                using (StreamReader sr = new StreamReader(arquivo)) {
                    while (!sr.EndOfStream) {
                        string linha = sr.ReadLine();
                        string[] campos = linha.Split(';');
                        int id;
                        int.TryParse(campos[0], out id);
                        string nome = campos[1];
                        string endereco = campos[2];
                        string telefone = campos[3];
                        string email = campos[4];
                        Cliente cliente = new Cliente(id, nome, endereco, telefone, email);
                        clientes.Add(cliente);
                        ultimoID = id;
                    }
                }
            }

            while (true) {

                Console.WriteLine("=== CADASTRO DE CLIENTES ===");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Editar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Listar todos");
                Console.WriteLine("0 - Sair");
                int opcao;
                while (!checkInt("Opção: ", out opcao)) ;

                switch (opcao) {
                    case 1:
                        ultimoID++;
                        Console.WriteLine("Nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Endereco: ");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("Telefone: ");
                        string telefone = Console.ReadLine();
                        string email = pedirEmail("Email: ");
                        Cliente cliente = new Cliente(ultimoID, nome, endereco, telefone, email);
                        clientes.Add(cliente);
                        break;
                    case 2:
                        int id;
                        while (!checkInt("ID do cliente a ser editado: ", out id)) ;
                        Cliente clienteTroca = checkIdCliente(clientes, id);
                        if (clienteTroca == null)
                        {
                            Console.WriteLine("Cliente não encontrado.");
                        }
                        else {
                            
                            Console.WriteLine("Nome: ");
                            string nomeTroca = Console.ReadLine();
                            Console.WriteLine("Endereço: ");
                            string enderecoTroca = Console.ReadLine();
                            Console.WriteLine("Telefone: ");
                            string telefoneTroca = Console.ReadLine();
                            string emailTroca = pedirEmail("Email: ");

                            clienteTroca.Nome = nomeTroca;
                            clienteTroca.Endereco = enderecoTroca;
                            clienteTroca.Telefone = telefoneTroca;
                            clienteTroca.Email = emailTroca;

                            using (StreamWriter sw = new StreamWriter(arquivo)) {
                                foreach (Cliente c in clientes) {
                                    sw.WriteLine($"{c.Id};{c.Nome};{c.Endereco};{c.Telefone};{c.Email}");
                                }
                            }

                        }
                        break;
                    case 3:
                        int idExcluir;
                        while (!checkInt("Id do cliente a ser excluido: ", out idExcluir)) ;
                        Cliente clienteExcluir = checkIdCliente(clientes, idExcluir);
                        if (clienteExcluir == null)
                        {
                            Console.WriteLine("Cliente não encontrado. ");
                        }
                        else {
                            

                            clientes.Remove(clienteExcluir);

                            using (StreamWriter sw = new StreamWriter(arquivo))
                            {
                                foreach (Cliente c in clientes)
                                {
                                    sw.WriteLine($"{c.Id};{c.Nome};{c.Endereco};{c.Telefone};{c.Email}");
                                }
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("=== LISTA DE CLIENTES ===");
                        foreach (Cliente clienteEscreve in clientes)
                        {
                            Console.WriteLine($"{clienteEscreve.Id};{clienteEscreve.Nome};{clienteEscreve.Endereco};{clienteEscreve.Telefone};{clienteEscreve.Email}");
                            Console.WriteLine("--------------");
                        }
                        break;
                    case 0:

                        return;
                }
            }

        }
    }
}
