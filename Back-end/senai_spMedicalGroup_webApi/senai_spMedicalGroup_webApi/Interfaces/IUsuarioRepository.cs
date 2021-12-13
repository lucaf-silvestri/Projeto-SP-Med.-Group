using senai_spMedicalGroup_webApi.Domains;
using System.Collections.Generic;

namespace senai_spMedicalGroup_webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Usuario através de seu ID
        /// </summary>
        /// <param name="id">ID do Usuario buscado</param>
        /// <returns>O Usuario buscado</returns>
        Usuario ListarId(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os novos dados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Usuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idUsuario">id do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado com os novos dados</param>
        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Lista todos os Usuarios com suas respectivas listas de clientes
        /// </summary>
        /// <returns>Uma lista de Usuarios com seus clientes</returns>
        public List<Usuario> ListarComClientes();

        /// <summary>
        /// Lista todos os Usuarios com suas respectivas listas de medicos
        /// </summary>
        /// <returns>Uma lista de Usuarios com seus medicos</returns>
        public List<Usuario> ListarComMedicos();

        /// <summary>
        /// Busca um usuário através de seu email e senha
        /// </summary>
        /// <param name="email">Email do usuário buscado</param>
        /// <param name="senha">Senha do usuário buscado</param>
        /// <returns>Usuário buscado</returns>
        Usuario Login(string email, string senha);
    }
}