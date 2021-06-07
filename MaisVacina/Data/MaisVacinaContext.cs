using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MaisVacina.Models;

namespace MaisVacina.Data
{
    public class MaisVacinaContext : DbContext
    {
        public MaisVacinaContext (DbContextOptions<MaisVacinaContext> options)
            : base(options)
        {
        }

        public DbSet<MaisVacina.Models.Cadastro> Cadastro { get; set; }
    }
}
