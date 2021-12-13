using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as Situacoes
        /// </summary>
        /// <returns>Lista de Situacoes</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma Clinica através de seu ID
        /// </summary>
        /// <param name="id">ID da Clinica buscada</param>
        /// <returns>A Clinica buscada</returns>
        Clinica ListarId(int id);

        /// <summary>
        /// Cadastra uma nova Clinica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica com os novos dados</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma Clinica existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idClinica">id da Clinica que será atualizada</param>
        /// <param name="ClinicaAtualizada">Objeto ClinicaAtualizada com os novos dados</param>
        void Atualizar(int idClinica, Clinica ClinicaAtualizada);

        /// <summary>
        /// Deleta uma Clinica existente
        /// </summary>
        /// <param name="idClinica">ID da Clinica deletada</param>
        void Deletar(int idClinica);

        /// <summary>
        /// Lista todas as Clinicas com suas respectivas listas de medicos
        /// </summary>
        /// <returns>Uma lista de Clinicas com seus medicos</returns>
        public List<Clinica> ListarComMedicos();
    }
}