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
        [Required]
        public String Nomelogin { get; set; }
        [Display(Name = "Email:")]
        [Required]
        public string Emaillogin { get; set; }

        [Display(Name = "Senha:")]
        [Required]
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
