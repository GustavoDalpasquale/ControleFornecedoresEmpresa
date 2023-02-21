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
    public class FornecedorController : ControllerBase
    {
        private IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Fornecedor>>> GetFornecedores()
        {
            try
            {
                var fornecedores = await _fornecedorRepositorio.GetFornecedores();
                return Ok(fornecedores);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter fornecedores.");
            }
        }

        [HttpGet("{id:int}", Name = "GetFornecedorPorId")]
        public async Task<ActionResult<Empresa>> GetFornecedorPorId(int id)
        {
            try
            {
                var fornecedor = await _fornecedorRepositorio.GetFornecedorPorId(id);
                return Ok(fornecedor);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter fornecedor por id.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Fornecedor fornecedor)
        {
            try
            {
                await _fornecedorRepositorio.CreateFornecedor(fornecedor);
                return CreatedAtRoute(nameof(GetFornecedorPorId), new { id = fornecedor.Id }, fornecedor);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao cadastrar fornecedor.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Fornecedor fornecedor)
        {
            try
            {
                if (fornecedor.Id == id)
                {
                    await _fornecedorRepositorio.UpdateFornecedor(fornecedor);
                    return Ok($"Fornecedor com id {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch
            {
                return BadRequest("Erro ao editar fornecedor.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var fornecedor = await _fornecedorRepositorio.GetFornecedorPorId(id);
                if (fornecedor != null)
                {
                    await _fornecedorRepositorio.DeleteFornecedor(fornecedor);
                    return Ok($"Fornecedor de id {id} deletado com sucesso!");
                }
                else
                {
                    return NotFound($"Fornecedor com id {id} não encontrado.");
                }
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
        }
    }
}
