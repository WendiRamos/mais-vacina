using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisVacina.Models
{
    public class Login
    {
        [Key]
        public int Idlogin { get; set; }

        [Display(Name ="Nome:")]
        public String Nomelogin { get; set; }


        [Display(Name = "Usuário:")]
        public String Usuario { get; set; }


        [Display(Name = "Email:")]
        public string Emaillogin { get; set; }


        [Display(Name = "Senha:")]
        public string Senhalogin { get; set; }


        public Login()
        {

        }

        public Login(int idlogin, string nomelogin, string emaillogin, string senhalogin)
        {
            Idlogin = idlogin;
            Nomelogin = nomelogin;
            Emaillogin = emaillogin;
            Senhalogin = senhalogin;
        }
    }
  


}
