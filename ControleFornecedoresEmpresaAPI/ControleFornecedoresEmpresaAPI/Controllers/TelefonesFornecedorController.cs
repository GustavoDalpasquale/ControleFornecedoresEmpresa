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
    public class TelefonesFornecedorController : ControllerBase
    {
        private ITelefonesFornecedorRepositorio _telefonesFornecedorRepositorio;

        public TelefonesFornecedorController(ITelefonesFornecedorRepositorio telefonesFornecedorRepositorio)
        {
            _telefonesFornecedorRepositorio = telefonesFornecedorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TelefonesFornecedor>>> GetTelefones()
        {
            try
            {
                var telefones = await _telefonesFornecedorRepositorio.GetTelefones();
                return Ok(telefones);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter telefones dos fornecedores.");
            }
        }

        [HttpGet("{id:int}", Name = "GetTelefonePorId")]
        public async Task<ActionResult<Empresa>> GetTelefonePorId(int id)
        {
            try
            {
                var telefone = await _telefonesFornecedorRepositorio.GetTelefonePorId(id);
                return Ok(telefone);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter primeiro telefone por id do fornecedor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(TelefonesFornecedor telefone)
        {
            try
            {
                await _telefonesFornecedorRepositorio.CreateTelefoneFornecedor(telefone);
                return CreatedAtRoute(nameof(GetTelefonePorId), new { id = telefone.Id }, telefone);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao cadastrar fornecedor.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] TelefonesFornecedor telefone)
        {
            try
            {
                if (telefone.Id == id)
                {
                    await _telefonesFornecedorRepositorio.UpdateTelefoneFornecedor(telefone);
                    return Ok($"Telefone com id {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch
            {
                return BadRequest("Erro ao editar telefone.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var telefone = await _telefonesFornecedorRepositorio.GetTelefonePorId(id);
                if (telefone != null)
                {
                    await _telefonesFornecedorRepositorio.DeleteTelefoneFornecedor(telefone);
                    return Ok($"Telefone de id {id} deletado com sucesso!");
                }
                else
                {
                    return NotFound($"Telefone com id {id} não encontrado.");
                }
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
        }
    }
}
