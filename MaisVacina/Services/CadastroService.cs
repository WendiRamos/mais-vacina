using MaisVacina.Data;
using MaisVacina.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisVacina.Services
{
    public class CadastroService
    {
        private readonly MaisVacinaContext _context;
        

        public CadastroService(MaisVacinaContext context)
        {
            _context = context;
       
        }
        public async Task<List<Cadastro>> FindByCadastro(String Nome)
        {
            var result = from obj in _context.Cadastro select obj;
            if (!string.IsNullOrEmpty(Nome))
            {
                result = result.Where(x => x.Nome.Contains(Nome)) ;
            }

            return await result
                  .ToListAsync();
                
        }


    }
}
