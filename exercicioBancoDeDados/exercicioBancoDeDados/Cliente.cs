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
        private string endereco;
        private string telefone;
        private string email;

        public Cliente(int id,string nome, string endereco, string telefone, string email)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
    }
}
