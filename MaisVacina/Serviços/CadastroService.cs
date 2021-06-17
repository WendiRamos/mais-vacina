
using MaisVacina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MaisVacina.Serviços.Exceptions;
using MaisVacina.Data;

namespace MaisVacina.Serviços
{
    public class CadastroService
    {
        private readonly MaisVacinaContext _context;

        public CadastroService(MaisVacinaContext context)
        {
            _context = context;
        }

        public async Task<List<Cadastro>> FindAllAsync()
        {//Taks é um obj que encapsula o processamento assincrono
         // await avisa que a chamada vai ser assincrona
            return await _context.Cadastro.ToListAsync();

        }
        public async Task InsertAsync(Cadastro obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Cadastro> FindByIdAsync(int id)
        {
            return await _context.Cadastro.Include(obj => obj.Id).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Cadastro.FindAsync(id);
                _context.Cadastro.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException )
            {
                throw new IntegrityException("Não é possível excluir o cadastro, cadastro sem informações!");
            }
        }

        public async Task UpdateAsync(Cadastro obj)
        {
            bool hasAny = await _context.Cadastro.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não existe!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }//Interceptando uma exceção de acesso a dados, e relançando minha excessão em nível de serviço.
            //Importante para segregar as camadas.
        }
    }
}