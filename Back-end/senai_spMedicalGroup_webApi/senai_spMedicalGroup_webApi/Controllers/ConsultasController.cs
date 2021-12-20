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

    /// <summary>
    /// Controller responsável pelos endpoints das consultas.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        /// <summary>
        /// Objeto _ConsultaRepository que irá receber todos os métodos definidos na interface IConsultaRepository
        /// </summary>
        public ConsultasController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as Situacoes
        /// </summary>
        /// <returns>Lista de Situacoes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Consultum> listaConsultas = _ConsultaRepository.Listar();
            return Ok(listaConsultas);
        }

        /// <summary>
        /// Busca uma Consulta através de seu ID
        /// </summary>
        /// <param name="id">ID da Consulta buscada</param>
        /// <returns>A Consulta buscada</returns>
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

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta com os novos dados</param>
        [HttpPost]
        public IActionResult Post(Consultum novaConsulta)
        {
            _ConsultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="id">ID da Consulta deletada</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ConsultaRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza uma Consulta existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idConsulta">id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtualizada">Objeto ConsultaAtualizada com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int idConsulta, Consultum ConsultaAtualizada)
        {
            Consultum ConsultaBuscado = _ConsultaRepository.ListarId(idConsulta);

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
                _ConsultaRepository.Atualizar(idConsulta, ConsultaAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista as consultas ligadas a um usuário específico
        /// </summary>
        /// <returns>Lista de consultas</returns>
        [HttpGet("especifico")]
        public IActionResult ListarEspecifico()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_ConsultaRepository.ListarEspecifico(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    erro
                });
            }
        }

        /// <summary>
        /// Adiciona descrição a uma consulta existente
        /// </summary>
        /// <param name="idConsulta">Id da consulta que terá a descrição adicionada</param>
        /// <param name="novaConsulta">Consulta com a nova Descrição</param>
        [HttpPatch("descricao/{idConsulta}")]
        public IActionResult AdicionarDescricao(int idConsulta, Consultum novaConsulta)
        {
            try
            {
                _ConsultaRepository.AdicionarDecricao(idConsulta, novaConsulta);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}