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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ListarId(idTipoUsuario);

            if (TipoUsuarioBuscado != null)
            {
                TipoUsuarioBuscado.TipoUsuario1 = TipoUsuarioAtualizado.TipoUsuario1;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = ListarId(idTipoUsuario);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario ListarId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == id);
        }

        List<TipoUsuario> ITipoUsuarioRepository.ListarComUsuarios()
        {
            return ctx.TipoUsuarios.Include(c => c.Usuarios).OrderBy(c => c.IdTipoUsuario).ToList();
        }
    }
}