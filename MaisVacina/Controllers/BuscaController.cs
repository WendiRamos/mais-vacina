using MaisVacina.Data;
using MaisVacina.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisVacina.Controllers
{
    public class BuscaController : Controller
    {
        private readonly MaisVacinaContext _context;

        public BuscaController(MaisVacinaContext context)
        {
            _context = context;
        }
        public IActionResult Search()
        {
            return View();
        }
       // public async Task<IActionResult> IndexParcial(string? termo)
      //  {
           // IQueryable<Cadastro> query = _context.Cadastro;
           // var list = await query.ToListAsync(); 
          //  list = (termo == null) ? list : list.FindAll(s => s.FullName.Contains(searchValue)); 
         //   return PartialView(await list);
       // }

    }
}
