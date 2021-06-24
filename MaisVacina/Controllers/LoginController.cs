using MaisVacina.Data;
using MaisVacina.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
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
        [HttpPost]
        public async Task<IActionResult> Logar(string Emaillogin, string Senhalogin)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;database=maisvacinadb;uid=root;password=luizcarlos");
            await mySqlConnection.OpenAsync();
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM login WHERE Emaillogin = '{Emaillogin}' AND Senhalogin='{Senhalogin}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
            
                return RedirectToAction(nameof(Index));

            }
            return Json(new { Msg = "Usuário não encontrado! Verifique suas credenciais!" });
        }

        public async Task<IActionResult> ConfirmRegister(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                 .FirstOrDefaultAsync(m => m.Idlogin == Id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email,Senha")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ConfirmRegister), new { Id = login.Idlogin });
            }
            return View(login);
        }
    }
}
