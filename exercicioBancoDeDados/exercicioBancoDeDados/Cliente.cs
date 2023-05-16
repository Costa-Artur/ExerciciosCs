using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioBancoDeDados
{
    class Cliente
    {
        private int id;
        private string nome;
        private string telefone;
        private string endereco;
        private string email;

        public Cliente()
        {
        }

        public Cliente(int id, string nome, string telefone, string endereco, string email)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
    }
}
