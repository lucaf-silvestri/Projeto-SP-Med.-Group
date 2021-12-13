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
    public class EspecialidadeMedicoRepository : IEspecialidadeMedicoRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idEspecialidadeMedico, EspecialidadeMedico EspecialidadeMedicoAtualizado)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = ListarId(idEspecialidadeMedico);

            if (EspecialidadeMedicoBuscado != null)
            {
                EspecialidadeMedicoBuscado.NomeEspecialidade = EspecialidadeMedicoAtualizado.NomeEspecialidade;
            }

            ctx.EspecialidadeMedicos.Update(EspecialidadeMedicoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(EspecialidadeMedico novoEspecialidadeMedico)
        {
            ctx.EspecialidadeMedicos.Add(novoEspecialidadeMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idEspecialidadeMedico)
        {
            EspecialidadeMedico EspecialidadeMedicoBuscado = ListarId(idEspecialidadeMedico);

            ctx.EspecialidadeMedicos.Remove(EspecialidadeMedicoBuscado);

            ctx.SaveChanges();
        }

        public List<EspecialidadeMedico> Listar()
        {
            return ctx.EspecialidadeMedicos.ToList();
        }

        public List<EspecialidadeMedico> ListarComMedicos()
        {
            return ctx.EspecialidadeMedicos.Include(c => c.Medicos).OrderBy(c => c.IdEspecialidadeMedico).ToList();
        }

        public EspecialidadeMedico ListarId(int id)
        {
            return ctx.EspecialidadeMedicos.FirstOrDefault(c => c.IdEspecialidadeMedico == id);
        }
    }
}