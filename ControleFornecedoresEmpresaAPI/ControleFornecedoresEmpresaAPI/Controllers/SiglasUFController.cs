using ControleFornecedoresEmpresaAPI.Models;
using ControleFornecedoresEmpresaAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter siglas UF.");
            }

        }

        [HttpGet("{id:int}", Name = "GetSiglasUFPorId")]
        public async Task<ActionResult<SiglasUF>> GetSiglasUFPorID(int id)
        {
            try
            {
                var sigla = await _siglasUFRepositorio.GetSiglasUFPorId(id);
                if (sigla == null)
                {
                    return BadRequest($"Não foi encontrado Sigla UF com id {id}.");
                }
                return sigla;
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter sigla da UF por id.");
            }
        }
    }


}
