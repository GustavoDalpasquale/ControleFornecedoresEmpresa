using ControleFornecedoresEmpresaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public interface IEmpresaRepositorio
    {
        Task<IEnumerable<Empresa>> GetEmpresas();
        Task<Empresa> GetEmpresaPorId(int id);
        Task CreateEmpresa(Empresa empresa);
        Task UpdateEmpresa(Empresa empresa);
        Task DeleteEmpresa(Empresa empresa);
        Task<IEnumerable<Empresa>> GetEmpresaPorNome(string nome);
    }
}
