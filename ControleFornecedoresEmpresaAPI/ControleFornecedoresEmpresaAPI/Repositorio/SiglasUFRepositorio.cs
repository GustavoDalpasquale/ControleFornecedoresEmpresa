using ControleFornecedoresEmpresaAPI.Context;
using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public class SiglasUFRepositorio : ISiglasUFRepositorio
    {
        private readonly AppDbContext _context;

        public SiglasUFRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SiglasUF>> GetSiglasUFs()
        {
            try
            {
                return await _context.TBSiglasUF.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
