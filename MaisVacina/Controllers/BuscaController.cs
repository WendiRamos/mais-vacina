using MaisVacina.Services;
using Microsoft.AspNetCore.Mvc;
using MaisVacina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisVacina.Controllers
{
    public class BuscaController : Controller
    {
        private readonly CadastroService _cadastroService;

        public BuscaController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public async Task<IActionResult> Search(string Nome)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["Nome"] = Nome;
                var result = await _cadastroService.FindByCadastro(Nome);
                return View(result);
            }
            return RedirectToAction("About", "Home");
        }
    }
}
