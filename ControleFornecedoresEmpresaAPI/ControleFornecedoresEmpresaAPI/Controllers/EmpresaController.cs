using ControleFornecedoresEmpresaAPI.Models;
using ControleFornecedoresEmpresaAPI.Repositorio;
using ControleFornecedoresEmpresaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepositorio _empresaRepositorio;

        public EmpresaController(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Empresa>>> GetEmpresas()
        {
            try
            {
                var empresas = await _empresaRepositorio.GetEmpresas();
                return Ok(empresas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter empresas.");

            }
        }

        [HttpGet("{id:int}", Name = "GetEmpresaPorId")]
        public async Task<ActionResult<Empresa>> GetEmpresaPorId(int id)
        {
            try
            {
                var empresa = await _empresaRepositorio.GetEmpresaPorId(id);
                if (empresa == null)
                {
                    return BadRequest($"Não foi encontrado empresa com id {id}.");
                }
                return Ok(empresa);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter empresa por id.");
            }
        }

        [HttpGet("{nome}", Name = "GetEmpresaPorNome")]
        public async Task<ActionResult<Empresa>> GetEmpresaPorNome(string nome)
        {
            try
            {
                var empresa = await _empresaRepositorio.GetEmpresaPorNome(nome);
                return Ok(empresa);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter empresa por nome.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Empresa empresa)
        {
            try
            {
                ValidacoesService valida = new ValidacoesService();
                if (!valida.ValidaCNPJ(empresa.CNPJ))
                {
                    return BadRequest("CNPJ inválido.");
                }
                await _empresaRepositorio.CreateEmpresa(empresa);
                return CreatedAtRoute(nameof(GetEmpresaPorId), new { id = empresa.Id }, empresa);
            }
            catch
            {
                if(empresa.Id != 0)
                {
                    return BadRequest("Erro ao cadastrar empresa. ID deve ser informado como zero.");
                }
                return BadRequest("Request inválido! Erro ao cadastrar empresa.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Empresa empresa)
        {
            try
            {
                if (empresa.Id == id)
                {
                    await _empresaRepositorio.UpdateEmpresa(empresa);
                    return Ok($"Empresa com id {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch
            {
                return BadRequest("Erro ao editar empresa.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var empresa = await _empresaRepositorio.GetEmpresaPorId(id);
                if (empresa != null)
                {
                    await _empresaRepositorio.DeleteEmpresa(empresa);
                    return Ok($"Empresa de id {id} deletado com sucesso!");
                }
                else
                {
                    return NotFound($"Empresa com id {id} não encontrado.");
                }
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
        }


    }
}
