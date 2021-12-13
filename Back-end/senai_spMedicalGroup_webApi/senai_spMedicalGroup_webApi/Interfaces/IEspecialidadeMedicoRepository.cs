using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório EspecialidadeMedicoRepository
    /// </summary>
    interface IEspecialidadeMedicoRepository
    {
        /// <summary>
        /// Lista todas as Situacoes
        /// </summary>
        /// <returns>Lista de Situacoes</returns>
        List<EspecialidadeMedico> Listar();

        /// <summary>
        /// Busca uma EspecialidadeMedico através de seu ID
        /// </summary>
        /// <param name="id">ID da EspecialidadeMedico buscada</param>
        /// <returns>A EspecialidadeMedico buscada</returns>
        EspecialidadeMedico ListarId(int id);

        /// <summary>
        /// Cadastra uma nova EspecialidadeMedico
        /// </summary>
        /// <param name="novaEspecialidadeMedico">Objeto novaEspecialidadeMedico com os novos dados</param>
        void Cadastrar(EspecialidadeMedico novaEspecialidadeMedico);

        /// <summary>
        /// Atualiza uma EspecialidadeMedico existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idEspecialidadeMedico">id da EspecialidadeMedico que será atualizada</param>
        /// <param name="EspecialidadeMedicoAtualizada">Objeto EspecialidadeMedicoAtualizada com os novos dados</param>
        void Atualizar(int idEspecialidadeMedico, EspecialidadeMedico EspecialidadeMedicoAtualizada);

        /// <summary>
        /// Deleta uma EspecialidadeMedico existente
        /// </summary>
        /// <param name="idEspecialidadeMedico">ID da EspecialidadeMedico deletada</param>
        void Deletar(int idEspecialidadeMedico);

        /// <summary>
        /// Lista todas as EspecialidadesMedico com suas respectivas listas de medicos
        /// </summary>
        /// <returns>Uma lista de EspecialidadesMedico com seus medicos</returns>
        public List<EspecialidadeMedico> ListarComMedicos();
    }
}