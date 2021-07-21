using System;
using System.ComponentModel.DataAnnotations;

namespace MaisVacina.Models
{
    public class Cadastro
    {
        
        public int Id { get; set; }
        public string CPF { get; set; }
        public String Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        
        public string Endereco { get; set; }
        public string Email { get; set; }

        public Cadastro()
        {
        }
        public Cadastro(int id, string Cpf, string nome, DateTime nascimento, string endereco, string email)
        {
            Id = id;
            CPF = Cpf;
            Nome = nome;
            Nascimento = nascimento;
            Endereco = endereco;
            Email = email;
        }
    }
}
