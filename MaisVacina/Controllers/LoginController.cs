using MaisVacina.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisVacina.Controllers
{
    public class LoginController : Controller
    {
        private readonly MaisVacinaContext _context;

        public LoginController(MaisVacinaContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
