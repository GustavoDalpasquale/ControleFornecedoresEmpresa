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
    public class TipoPessoaController : ControllerBase
    {
        private ITipoPessoaRepositorio _tipoPessoaRepositorio;

        public TipoPessoaController(ITipoPessoaRepositorio tipoPessoaRepositorio)
        {
            _tipoPessoaRepositorio = tipoPessoaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TipoPessoa>>> GetTipoPessoas()
        {
            try
            {
                var tipoPessoa = await _tipoPessoaRepositorio.GetTipoPessoas();
                return Ok(tipoPessoa);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter tipos de pessoa.");
            }

        }

        [HttpGet("{id:int}", Name = "GetTipoPessoaPorId")]
        public async Task<ActionResult<SiglasUF>> GetTipoPessoaPorId(int id)
        {
            try
            {
                var tipoPessoa = await _tipoPessoaRepositorio.GetTipoPessoaPorId(id);
                if (tipoPessoa == null)
                {
                    return BadRequest($"Não foi encontrado tipo pessoa com id {id}.");
                }
                return Ok(tipoPessoa);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter tipo de pessoa por id.");
            }
        }
    }
}
;