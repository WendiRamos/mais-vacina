using MaisVacina.Data;
using MaisVacina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                byte[] tmp = Encoding.GetEncoding("ISO-8859-8").GetBytes(Nome);
                string pesquisa = System.Text.Encoding.UTF8.GetString(tmp);
                result = result.Where(x => x.Nome.Contains(pesquisa));
            }
            return await result
                  .ToListAsync();
        }
    }
}
