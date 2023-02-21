using ControleFornecedoresEmpresaAPI.Context;
using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public class TelefonesFornecedorRepositorio : ITelefonesFornecedorRepositorio
    {
        private readonly AppDbContext _context;

        public TelefonesFornecedorRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TelefonesFornecedor>> GetTelefones()
        {
            try
            {
                return await _context.TBTelefonesFornecedor.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TelefonesFornecedor> GetTelefonePorId(int id)
        {
            try
            {
                return await _context.TBTelefonesFornecedor.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateTelefoneFornecedor(TelefonesFornecedor telefoneFornecedor)
        {
            _context.TBTelefonesFornecedor.Add(telefoneFornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTelefoneFornecedor(TelefonesFornecedor telefoneFornecedor)
        {
            _context.Entry(telefoneFornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelefoneFornecedor(TelefonesFornecedor telefoneFornecedor)
        {
            _context.TBTelefonesFornecedor.Remove(telefoneFornecedor);
            await _context.SaveChangesAsync();
        }
    }
}
