using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório MedicoRepository
    /// </summary>
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os Medicos
        /// </summary>
        /// <returns>Lista de Medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um Medico através de seu ID
        /// </summary>
        /// <param name="id">ID do Medico buscado</param>
        /// <returns>O Medico buscado</returns>
        Medico ListarId(int id);

        /// <summary>
        /// Cadastra um novo Medico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico com os novos dados</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza um Medico existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idMedico">id do Medico que será atualizado</param>
        /// <param name="MedicoAtualizado">Objeto MedicoAtualizado com os novos dados</param>
        void Atualizar(int idMedico, Medico MedicoAtualizado);

        /// <summary>
        /// Deleta um Medico existente
        /// </summary>
        /// <param name="idMedico">ID do Medico deletado</param>
        void Deletar(int idMedico);

        /// <summary>
        /// Lista todos os Medicos com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Medicos com suas consultas</returns>
        public List<Medico> ListarComConsultas();
    }
}