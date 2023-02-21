using ControleFornecedoresEmpresaAPI.Context;
using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public class TipoPessoaRepositorio : ITipoPessoaRepositorio
    {
        private readonly AppDbContext _context;

        public TipoPessoaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoPessoa>> GetTipoPessoas()
        {
            try
            {
                return await _context.TBTipoPessoa.ToListAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<TipoPessoa> GetTipoPessoaPorId(int id)
        {
            try
            {
                return await _context.TBTipoPessoa.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }        
    }
}
