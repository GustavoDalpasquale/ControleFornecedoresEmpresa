using ControleFornecedoresEmpresaAPI.Models;
using ControleFornecedoresEmpresaAPI.Repositorio;
using ControleFornecedoresEmpresaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFornecedoresEmpresaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private IFornecedorRepositorio _fornecedorRepositorio;
        private ITipoPessoaRepositorio _tipoPessoaRepositorio;
        private IEmpresaRepositorio _empresaRepositorio;
        private ISiglasUFRepositorio _siglasUFRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio, ITipoPessoaRepositorio tipoPessoaRepositorio, IEmpresaRepositorio empresaRepositorio, ISiglasUFRepositorio siglasUFRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _tipoPessoaRepositorio = tipoPessoaRepositorio;
            _empresaRepositorio = empresaRepositorio;
            _siglasUFRepositorio = siglasUFRepositorio;
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
        public async Task<ActionResult<Fornecedor>> GetFornecedorPorId(int id)
        {
            try
            {
                var fornecedor = await _fornecedorRepositorio.GetFornecedorPorId(id);
                if (fornecedor == null)
                {
                    return BadRequest($"Não foi encontrado fornecedor com id {id}.");
                }
                return Ok(fornecedor);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter fornecedor por id.");
            }
        }

        [HttpGet("{nome}", Name = "GetFornecedorPorNome")]
        public async Task<ActionResult<Fornecedor>> GetFornecedorPorNome(string nome)
        {
            try
            {
                var fornecedor = await _fornecedorRepositorio.GetFornecedorPorNome(nome);
                return Ok(fornecedor);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter fornecedor por nome.");
            }
        }

        [HttpGet("[action]/{cpfcnpj}", Name = "GetFornecedorPorCPFCNPJ")]
        public async Task<ActionResult<Fornecedor>> GetFornecedorPorCPFCNPJ(string cpfcnpj)
        {
            try
            {
                ValidacoesService valida = new ValidacoesService();
                var fornecedor = await _fornecedorRepositorio.GetFornecedorPorCPFCNPJ(valida.LimpaCPFCNPJ(cpfcnpj));
                return Ok(fornecedor);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter fornecedor por CPF/CNPJ.");
            }
        }

        [HttpGet("{dataCadastroPesquisada:DateTime}", Name = "GetFornecedorPorDataCadastro")]
        public async Task<ActionResult<Fornecedor>> GetFornecedorPorDataCadastro(DateTime dataCadastroPesquisada)
        {
            try
            {
                var fornecedor = await _fornecedorRepositorio.GetFornecedorPorDataCadastro(dataCadastroPesquisada);
                return Ok(fornecedor);
            }
            catch
            {
                return BadRequest("Request inválido! Erro ao obter fornecedor por data de cadastro.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Fornecedor fornecedor)
        {
            try
            {
                ValidacoesService valida = new ValidacoesService();

                if (valida.ValidaCPF(fornecedor.CPFCNPJ) || valida.ValidaCNPJ(fornecedor.CPFCNPJ))
                {
                    TipoPessoa tipo = await _tipoPessoaRepositorio.GetTipoPessoaPorId(fornecedor.IdTipoPessoa);
                    if (tipo.Tipo == "Física")
                    {
                        if (fornecedor.DataNascimento == null)
                        {
                            return BadRequest("É obrigatório preencher o nascimento quando o fornecedor for do tipo pessoa jurídico.");
                        }
                        Empresa empresa = await _empresaRepositorio.GetEmpresaPorId(fornecedor.IdEmpresa);
                        SiglasUF sigla = await _siglasUFRepositorio.GetSiglasUFPorId(empresa.IdSiglasUF);
                        if (sigla.Sigla == "PR")
                        {
                            if (!(valida.ValidaNascimentoMaiorDeIdade(fornecedor.DataNascimento.Value)))
                            {
                                return BadRequest("Fornecedor do tipo pessoa jurídico precisa ser maior de idade (18 anos ou superior) para ser vinculado a uma empresa de Paraná.");
                            }
                        }
                    }
                    await _fornecedorRepositorio.CreateFornecedor(fornecedor);
                    return CreatedAtRoute(nameof(GetFornecedorPorId), new { id = fornecedor.Id }, fornecedor);
                }
                else
                {
                    return BadRequest("CPF/CNPJ inválido.");
                }
            }
            catch
            {
                if (fornecedor.Id != 0)
                {
                    return BadRequest("Erro ao cadastrar fornecedor. ID deve ser informado como zero.");
                }
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
