using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ConsultaRepository
    /// </summary>
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as Situacoes
        /// </summary>
        /// <returns>Lista de Situacoes</returns>
        List<Consultum> Listar();

        /// <summary>
        /// Busca uma Consulta através de seu ID
        /// </summary>
        /// <param name="id">ID da Consulta buscada</param>
        /// <returns>A Consulta buscada</returns>
        Consultum ListarId(int id);

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta com os novos dados</param>
        void Cadastrar(Consultum novaConsulta);

        /// <summary>
        /// Atualiza uma Consulta existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idConsulta">id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtualizada">Objeto ConsultaAtualizada com os novos dados</param>
        void Atualizar(int idConsulta, Consultum ConsultaAtualizada);

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="idConsulta">ID da Consulta deletada</param>
        void Deletar(int idConsulta);

        /// <summary>
        /// Lista as consultas ligadas a um usuário específico
        /// </summary>
        /// <param name="idUsuario">Id do usuário que terá as consultas listadas</param>
        /// <returns>Lista de consultas</returns>
        List<Consultum> ListarEspecifico(int idUsuario);

        /// <summary>
        /// Adiciona descrição a uma consulta existente
        /// </summary>
        /// <param name="idConsulta">Id da consulta que terá a descrição adicionada</param>
        /// <param name="ConsultaDescricao">objeto com atributo descrição</param>
        void AdicionarDecricao(int idConsulta, Consultum ConsultaDescricao);
    }
}