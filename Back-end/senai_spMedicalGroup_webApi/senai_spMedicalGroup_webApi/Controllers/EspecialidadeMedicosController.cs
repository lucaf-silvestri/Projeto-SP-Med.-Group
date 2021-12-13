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
    public class EspecialidadeMedicosController : ControllerBase
    {
        private IEspecialidadeMedicoRepository _EspecialidadeMedicoRepository { get; set; }

        public EspecialidadeMedicosController()
        {
            _EspecialidadeMedicoRepository = new EspecialidadeMedicoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EspecialidadeMedico> listaEspecialidadeMedicos = _EspecialidadeMedicoRepository.Listar();
            return Ok(listaEspecialidadeMedicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = _EspecialidadeMedicoRepository.ListarId(id);

            if (EspecialidadeMedicoBuscado == null)
            {
                return NotFound("Nenhuma EspecialidadeMedico encontrada.");
            }

            return Ok(EspecialidadeMedicoBuscado);
        }

        [HttpPost]
        public IActionResult Post(EspecialidadeMedico novoEspecialidadeMedico)
        {
            _EspecialidadeMedicoRepository.Cadastrar(novoEspecialidadeMedico);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _EspecialidadeMedicoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EspecialidadeMedico EspecialidadeMedicoAtualizado)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = _EspecialidadeMedicoRepository.ListarId(id);

            if (EspecialidadeMedicoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "EspecialidadeMedico não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _EspecialidadeMedicoRepository.Atualizar(id, EspecialidadeMedicoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("medicos")]
        public IActionResult ListarComMedicos()
        {
            try
            {
                return Ok(_EspecialidadeMedicoRepository.ListarComMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}