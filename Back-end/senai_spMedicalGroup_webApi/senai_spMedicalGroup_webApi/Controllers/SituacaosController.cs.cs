using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using senai_spMedicalGroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_spMedicalGroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaosController : ControllerBase
    {
        private ISituacaoRepository _SituacaoRepository { get; set; }

        public SituacaosController()
        {
            _SituacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Situacao> listaSituacaos = _SituacaoRepository.Listar();
            return Ok(listaSituacaos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Situacao SituacaoBuscado = _SituacaoRepository.ListarId(id);

            if (SituacaoBuscado == null)
            {
                return NotFound("Nenhuma Situacao encontrada.");
            }

            return Ok(SituacaoBuscado);
        }

        [HttpPost]
        public IActionResult Post(Situacao novoSituacao)
        {
            _SituacaoRepository.Cadastrar(novoSituacao);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _SituacaoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Situacao SituacaoAtualizado)
        {
            Situacao SituacaoBuscado = _SituacaoRepository.ListarId(id);

            if (SituacaoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Situacao não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _SituacaoRepository.Atualizar(id, SituacaoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("consultas")]
        public IActionResult ListarComConsultas()
        {
            try
            {
                return Ok(_SituacaoRepository.ListarComConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}