using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisVacina.Models
{
    public class Login
    {
        public int Idlogin { get; set; }
        public String Nomelogin { get; set; }
        public string Emaillogin { get; set; }
        public string Senhalogin { get; set; }
        public string Senhalogin2 { get; set; }
        public Login()
        {

        }

        public Login(int idlogin, string nomelogin, string emaillogin, string senhalogin, string senhalogin2)
        {
            Idlogin = idlogin;
            Nomelogin = nomelogin;
            Emaillogin = emaillogin;
            Senhalogin = senhalogin;
            Senhalogin2 = senhalogin2;
        }
    }
  


}
