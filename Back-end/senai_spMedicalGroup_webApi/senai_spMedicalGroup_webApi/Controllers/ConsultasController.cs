using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using senai_spMedicalGroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace senai_spMedicalGroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultasController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Consultum> listaConsultas = _ConsultaRepository.Listar();
            return Ok(listaConsultas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Consultum ConsultaBuscado = _ConsultaRepository.ListarId(id);

            if (ConsultaBuscado == null)
            {
                return NotFound("Nenhuma Consulta encontrada.");
            }

            return Ok(ConsultaBuscado);
        }

        [HttpPost]
        public IActionResult Post(Consultum novoConsulta)
        {
            _ConsultaRepository.Cadastrar(novoConsulta);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ConsultaRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consultum ConsultaAtualizado)
        {
            Consultum ConsultaBuscado = _ConsultaRepository.ListarId(id);

            if (ConsultaBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Consulta não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _ConsultaRepository.Atualizar(id, ConsultaAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPatch("situacao/{idConsulta}")]
        public IActionResult AtualizarSituacao(int idConsulta, Consultum ConsultaSituacao)
        {
            try
            {
                _ConsultaRepository.AtualizarSituacao(idConsulta, ConsultaSituacao.IdSituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPatch("descricao/{idConsulta}")]
        public IActionResult AtualizarDescricao(int idConsulta, Consultum ConsultaAtualizada)
        {
            try
            {
                _ConsultaRepository.AtualizarDescricao(idConsulta, ConsultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

    }
}