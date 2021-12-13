using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório SituacaoRepository
    /// </summary>
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todas as Situacoes
        /// </summary>
        /// <returns>Lista de Situacoes</returns>
        List<Situacao> Listar();

        /// <summary>
        /// Busca uma Situacao através de seu ID
        /// </summary>
        /// <param name="id">ID da Situacao buscada</param>
        /// <returns>A Situacao buscada</returns>
        Situacao ListarId(int id);

        /// <summary>
        /// Cadastra uma nova Situacao
        /// </summary>
        /// <param name="novaSituacao">Objeto novaSituacao com os novos dados</param>
        void Cadastrar(Situacao novaSituacao);

        /// <summary>
        /// Atualiza uma Situacao existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idSituacao">id da Situacao que será atualizada</param>
        /// <param name="SituacaoAtualizada">Objeto SituacaoAtualizada com os novos dados</param>
        void Atualizar(int idSituacao, Situacao SituacaoAtualizada);

        /// <summary>
        /// Deleta uma Situacao existente
        /// </summary>
        /// <param name="idSituacao">ID da Situacao deletada</param>
        void Deletar(int idSituacao);

        /// <summary>
        /// Lista todas as Situacoes com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Situacoes com suas consultas</returns>
        public List<Situacao> ListarComConsultas();
    }
}