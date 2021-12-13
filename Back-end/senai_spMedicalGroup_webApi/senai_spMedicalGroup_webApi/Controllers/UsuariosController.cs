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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> listaUsuarios = _UsuarioRepository.Listar();
            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.ListarId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado.");
            }

            return Ok(UsuarioBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.ListarId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuário não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _UsuarioRepository.Atualizar(id, UsuarioAtualizado);

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
                return Ok(_UsuarioRepository.ListarComMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("clientes")]
        public IActionResult ListarComClientes()
        {
            try
            {
                return Ok(_UsuarioRepository.ListarComClientes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}