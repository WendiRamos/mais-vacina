using System;

namespace MaisVacina.Models
{
    public class Cadastro
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public String Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Endereço { get; set; }
        public string Email { get; set; }
        public Cadastro() { }
        public Cadastro(int id, string Cpf, string nome, DateTime nascimento, string endereço, string email)
        {
            Id = id;
            CPF = Cpf;
            Nome = nome;
            Nascimento = nascimento;
            Endereço = endereço;
            Email = email;
        }
    }
}
