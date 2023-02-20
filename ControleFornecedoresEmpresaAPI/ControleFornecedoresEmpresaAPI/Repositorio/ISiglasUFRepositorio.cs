using ControleFornecedoresEmpresaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Repositorio
{
    public interface ISiglasUFRepositorio
    {
        Task<IEnumerable<SiglasUF>> GetSiglasUFs();
    }
}
