using ControleFornecedoresEmpresaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public interface ITipoPessoaRepositorio
    {
        Task<IEnumerable<TipoPessoa>> GetTipoPessoas();
        Task<TipoPessoa> GetTipoPessoaPorId(int id);
    }
}
