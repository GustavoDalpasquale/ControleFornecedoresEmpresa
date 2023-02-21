using ControleFornecedoresEmpresaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public interface ITelefonesFornecedorRepositorio
    {
        Task<IEnumerable<TelefonesFornecedor>> GetTelefones();
        Task<TelefonesFornecedor> GetTelefonePorId(int id);   
        Task CreateTelefoneFornecedor(TelefonesFornecedor telefoneFornecedor);
        Task UpdateTelefoneFornecedor(TelefonesFornecedor telefoneFornecedor);
        Task DeleteTelefoneFornecedor(TelefonesFornecedor telefoneFornecedor);
    }
}
