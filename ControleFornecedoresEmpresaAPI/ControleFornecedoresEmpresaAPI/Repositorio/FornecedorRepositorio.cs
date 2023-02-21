using ControleFornecedoresEmpresaAPI.Context;
using ControleFornecedoresEmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly AppDbContext _context;

        public FornecedorRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedores()
        {
            try
            {
                return await _context.TBFornecedor.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Fornecedor> GetFornecedorPorId(int id)
        {
            try
            {
                return await _context.TBFornecedor.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedorPorNome(string nome)
        {
            IEnumerable<Fornecedor> fornecedores;
            if (!string.IsNullOrEmpty(nome))
            {
                fornecedores = await _context.TBFornecedor.Where(fornecedor => fornecedor.Nome.ToUpper().StartsWith(nome.ToUpper())).ToListAsync();
            }
            else
            {
                fornecedores = await GetFornecedores();
            }
            return fornecedores;
        }

        public async Task CreateFornecedor(Fornecedor fornecedor)
        {
            _context.TBFornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFornecedor(Fornecedor fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFornecedor(Fornecedor fornecedor)
        {
            _context.TBFornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();
        }                
    }
}
