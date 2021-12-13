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
    public class ClinicaRepository : IClinicaRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idClinica, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscado = ListarId(idClinica);

            if (ClinicaBuscado != null)
            {
                ClinicaBuscado.EnderecoClinica = ClinicaAtualizado.EnderecoClinica;
                ClinicaBuscado.HorarioInicio = ClinicaAtualizado.HorarioInicio;
                ClinicaBuscado.HorarioFim = ClinicaAtualizado.HorarioFim;
                ClinicaBuscado.Cnpj = ClinicaAtualizado.Cnpj;
                ClinicaBuscado.NomeFantasia = ClinicaAtualizado.NomeFantasia;
                ClinicaBuscado.RazaoSocial = ClinicaAtualizado.RazaoSocial;
            }

            ctx.Clinicas.Update(ClinicaBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Clinica novoClinica)
        {
            ctx.Clinicas.Add(novoClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica ClinicaBuscado = ListarId(idClinica);

            ctx.Clinicas.Remove(ClinicaBuscado);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }

        public List<Clinica> ListarComMedicos()
        {
            return ctx.Clinicas.Include(c => c.Medicos).OrderBy(c => c.IdClinica).ToList();
        }

        public Clinica ListarId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }
    }
}