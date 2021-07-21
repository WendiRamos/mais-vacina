using MaisVacina.Data;

using MaisVacina.Models;
using MaisVacina.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
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
            if (User.Identity.IsAuthenticated)
            {
                return null;
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(string Usuario, string Emaillogin, string Senhalogin)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=maisvacinadb;uid=root;password=luizcarlos");
            await mySqlConnection.OpenAsync();
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM login WHERE Usuario = '{Usuario}' AND Emaillogin = '{Emaillogin}' AND Senhalogin='{Senhalogin}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
                int Idlogin = reader.GetInt32(0);
                string nome = reader.GetString(1);

                List<Claim> direitosdeAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,Idlogin.ToString()),
                    new Claim(ClaimTypes.Name,nome)

                };

                var identity = new ClaimsIdentity(direitosdeAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.Now.AddHours(10)
                    });

                return RedirectToAction("Index", "Cadastro");

            }
            return RedirectToAction(nameof(Error), new { message = "Usuário não encontrado! Verifique suas credenciais!" });


        }
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("About", "Home");
        }

        public async Task<IActionResult> ConfirmRegister(int? Idlogin)
        {

            if (Idlogin == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var login = await _context.Login
                 .FirstOrDefaultAsync(m => m.Idlogin == Idlogin);
            if (login == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Verifique suas credenciais!, e tente novamente" });
            }

            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Nomelogin,Usuario,Emaillogin,Senhalogin")] Login login)
        {
            if (ModelState.IsValid )
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ConfirmRegister), new { login.Idlogin });
            }
            return View(login);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);


        }
    }
}
