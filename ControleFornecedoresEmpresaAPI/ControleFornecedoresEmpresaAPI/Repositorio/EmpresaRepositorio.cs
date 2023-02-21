using ControleFornecedoresEmpresaAPI.Context;
using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly AppDbContext _context;

        public EmpresaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresas()
        {
            try
            {
                return await _context.TBEmpresa.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Empresa> GetEmpresaPorId(int id)
        {
            try
            {
                return await _context.TBEmpresa.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateEmpresa(Empresa empresa)
        {
            _context.TBEmpresa.Add(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmpresa(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpresa(Empresa empresa)
        {
            _context.TBEmpresa.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}
