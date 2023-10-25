using ControleFornecedoresEmpresaAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public interface IFornecedorRepositorio
    {
        Task<IEnumerable<Fornecedor>> GetFornecedores();
        Task<Fornecedor> GetFornecedorPorId(int id);
        Task<IEnumerable<Fornecedor>> GetFornecedorPorNome(string nome);
        Task<IEnumerable<Fornecedor>> GetFornecedorPorCPFCNPJ(string cpfcnpj);
        Task<IEnumerable<Fornecedor>> GetFornecedorPorDataCadastro(DateTime dataCadastro);
        Task CreateFornecedor(Fornecedor fornecedor);
        Task UpdateFornecedor(Fornecedor fornecedor);
        Task DeleteFornecedor(Fornecedor fornecedor);
    }
}
