using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaisVacina.Data;
using MaisVacina.Models;
using MaisVacina.Models.ViewModels;
using MaisVacina.Serviços;
using System.Diagnostics;

namespace MaisVacina.Controllers
{
    public class CadastroController : Controller
    {
        private readonly MaisVacinaContext _context;

        public CadastroController(MaisVacinaContext context)
        {
            _context = context;
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(await _context.Cadastro.ToListAsync());
            }
            return RedirectToAction("About", "Home");
        }


        // GET: Cadastro/Details
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (cadastro == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe!" });
            }

            return View(cadastro);
        }


        // GET: Cadastro/Confirm
        public async Task<IActionResult> Confirm(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var cadastro = await _context.Cadastro
                 .FirstOrDefaultAsync(m => m.Id == Id);
            if (cadastro == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe!" });
            }

            return View(cadastro);
        }


        // GET: Cadastro/Create
        public IActionResult Create()
        {
            return View();
        }
        // GET: Cadastro/Create2
        public IActionResult Create2()
        {
            return View();
        }


        // POST: Cadastro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Nascimento,Endereço,CPF,Email")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        // POST: Cadastro/Create2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("Nome,Nascimento,Endereço,CPF,Email")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirm), new { Id = cadastro.Id });
            }
            return View(cadastro);
        }


        // GET: Cadastro/Edit
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (cadastro == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe!" });
            }

            return View(cadastro);
        }

        // POST: Cadastro/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Nascimento,Endereço,CPF,Email")] Cadastro cadastro)
        {

            if (id != cadastro.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondes!" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!CadastroExists(cadastro.Id))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            return View(cadastro);
        }

        // GET: Cadastro/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe!" });
            }

            return View(cadastro);
        }

        // POST: Cadastro/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);
            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int? id)
        {
            return _context.Cadastro.Any(e => e.Id == id);
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
