using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using senai_spMedicalGroup_webApi.Repositories;
using System;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuario> listaTipoUsuarios = _TipoUsuarioRepository.Listar();
            return Ok(listaTipoUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.ListarId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum TipoUsuario encontrado.");
            }

            return Ok(TipoUsuarioBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.ListarId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "TipoUsuario não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _TipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("usuarios")]
        public IActionResult ListarComUsuarios()
        {
            try
            {
                return Ok(_TipoUsuarioRepository.ListarComUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}