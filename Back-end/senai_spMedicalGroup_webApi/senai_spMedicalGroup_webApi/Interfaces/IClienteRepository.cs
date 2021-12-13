using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        /// <summary>
        /// Lista todos os Clientes
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        List<Cliente> Listar();

        /// <summary>
        /// Busca um Cliente através de seu ID
        /// </summary>
        /// <param name="id">ID do Cliente buscado</param>
        /// <returns>O Cliente buscado</returns>
        Cliente ListarId(int id);

        /// <summary>
        /// Cadastra um novo Cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com os novos dados</param>
        void Cadastrar(Cliente novoCliente);

        /// <summary>
        /// Atualiza um Cliente existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idCliente">id do Cliente que será atualizado</param>
        /// <param name="ClienteAtualizado">Objeto ClienteAtualizado com os novos dados</param>
        void Atualizar(int idCliente, Cliente ClienteAtualizado);

        /// <summary>
        /// Deleta um Cliente existente
        /// </summary>
        /// <param name="idCliente">ID do Cliente deletado</param>
        void Deletar(int idCliente);

        /// <summary>
        /// Lista todos os Clientes com suas respectivas listas de consultas
        /// </summary>
        /// <returns>Uma lista de Clientes com suas consultas</returns>
        public List<Cliente> ListarComConsultas();
    }
}