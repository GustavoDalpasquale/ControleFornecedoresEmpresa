using ControleFornecedoresEmpresaAPI.Models;
using ControleFornecedoresEmpresaAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiglasUFController : ControllerBase
    {
        private ISiglasUFRepositorio _siglasUFRepositorio;

        public SiglasUFController(ISiglasUFRepositorio siglasUFRepositorio)
        {
            _siglasUFRepositorio = siglasUFRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<SiglasUF>>> GetSiglasUFs()
        {
            try
            {
                var siglas = await _siglasUFRepositorio.GetSiglasUFs();
                return Ok(siglas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos.");
            }

        }
    }


}
