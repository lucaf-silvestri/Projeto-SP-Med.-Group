using Microsoft.EntityFrameworkCore;
using senai_spMedicalGroup_webApi.Contexts;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ListarId(idUsuario);

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario UsuarioBuscado = ListarId(idUsuario);

            ctx.Usuarios.Remove(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public List<Usuario> ListarComClientes()
        {
            return ctx.Usuarios.Include(c => c.Cliente).OrderBy(c => c.IdUsuario).ToList();
        }

        public List<Usuario> ListarComMedicos()
        {
            return ctx.Usuarios.Include(c => c.Medico).OrderBy(c => c.IdUsuario).ToList();
        }

        public Usuario ListarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
