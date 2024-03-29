﻿using ControleFornecedoresEmpresaAPI.Context;
using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<SiglasUF> GetSiglasUFPorId(int id)
        {
            try
            {
                return await _context.TBSiglasUF.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
