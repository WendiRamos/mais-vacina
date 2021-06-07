using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Cadastro(int id, string cPF, string nome, DateTime nascimento, string endereço, string email)
        {
            Id = id;
            CPF = cPF;
            Nome = nome;
            Nascimento = nascimento;
            Endereço = endereço;
            Email = email;
        }



        /* public bool ValidarCpf(string CPF)
         {
             int[] multiplicador1 = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
             int[] multiplicador2 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
             string tempCpf;
             string digito;
             int soma;
             int resto;
             CPF = CPF.Replace(".", "").Replace("-", "").Replace(" ", "");
             if (CPF.Length != 11)
                 return false;
             tempCpf = CPF.Substring(0, 9);
             soma = 0;

             for (int i = 0; i < 9; i++)
                 soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
             resto = soma % 11;
             if (resto == 10)
                 resto = 0;
             digito = resto.ToString();
             tempCpf = tempCpf + digito;
             soma = 0;
             soma = 0;
             for (int i = 0; i < 10; i++)
                 soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
             resto = soma % 11;
             if (resto == 10)
                 resto = 0;
             digito = digito + resto.ToString();
             return CPF.EndsWith(digito);
         }*/
    }
}
