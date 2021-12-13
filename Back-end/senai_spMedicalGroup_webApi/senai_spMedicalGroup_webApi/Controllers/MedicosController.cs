using Microsoft.AspNetCore.Authorization;
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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Medico> listaMedicos = _MedicoRepository.Listar();
            return Ok(listaMedicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Medico MedicoBuscado = _MedicoRepository.ListarId(id);

            if (MedicoBuscado == null)
            {
                return NotFound("Nenhum Medico encontrado.");
            }

            return Ok(MedicoBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            _MedicoRepository.Cadastrar(novoMedico);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _MedicoRepository.Deletar(id);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico MedicoAtualizado)
        {
            Medico MedicoBuscado = _MedicoRepository.ListarId(id);

            if (MedicoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Medico não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _MedicoRepository.Atualizar(id, MedicoAtualizado);

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
                return Ok(_MedicoRepository.ListarComConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}