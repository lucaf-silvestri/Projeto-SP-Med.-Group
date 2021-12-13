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
    public class SituacaoRepository : ISituacaoRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idSituacao, Situacao SituacaoAtualizado)
        {
            Situacao SituacaoBuscado = ListarId(idSituacao);

            if (SituacaoBuscado != null)
            {
                SituacaoBuscado.TipoSituacao = SituacaoAtualizado.TipoSituacao;
            }

            ctx.Situacaos.Update(SituacaoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Situacao novoSituacao)
        {
            ctx.Situacaos.Add(novoSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            Situacao SituacaoBuscado = ListarId(idSituacao);

            ctx.Situacaos.Remove(SituacaoBuscado);

            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacaos.ToList();
        }

        public List<Situacao> ListarComConsultas()
        {
            return ctx.Situacaos.Include(c => c.Consulta).OrderBy(c => c.IdSituacao).ToList();
        }

        public Situacao ListarId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(c => c.IdSituacao == id);
        }
    }
}