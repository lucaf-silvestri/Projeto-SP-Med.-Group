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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>Uma lista de clientes com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Cliente> listaClientes = _ClienteRepository.Listar();
            return Ok(listaClientes);
        }

        /// <summary>
        /// Busca um Cliente através de seu ID
        /// </summary>
        /// <param name="id">ID do Cliente buscado</param>
        /// <returns>O Cliente buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cliente ClienteBuscado = _ClienteRepository.ListarId(id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nenhum Cliente encontrado.");
            }

            return Ok(ClienteBuscado);
        }

        /// <summary>
        /// Cadastra um novo Cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com os novos dados</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Cliente novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Cliente existente
        /// </summary>
        /// <param name="id">ID do Cliente deletado</param>
        [Authorize(Roles = "1")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um Cliente existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do Cliente que será atualizado</param>
        /// <param name="ClienteAtualizado">Objeto ClienteAtualizado com os novos dados</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente ClienteAtualizado)
        {
            Cliente ClienteBuscado = _ClienteRepository.ListarId(id);

            if (ClienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _ClienteRepository.Atualizar(id, ClienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista todos os Clientes com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Clientes com suas consultas</returns>
        [HttpGet("consultas")]
        public IActionResult ListarComConsultas()
        {
            try
            {
                return Ok(_ClienteRepository.ListarComConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}