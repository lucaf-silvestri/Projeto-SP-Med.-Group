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
    public class MedicoRepository : IMedicoRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idMedico, Medico MedicoAtualizado)
        {
            Medico MedicoBuscado = ListarId(idMedico);

            if (MedicoBuscado != null)
            {
                MedicoBuscado.IdUsuario = MedicoAtualizado.IdUsuario;
                MedicoBuscado.IdEspecialidadeMedico = MedicoAtualizado.IdEspecialidadeMedico;
                MedicoBuscado.IdClinica = MedicoAtualizado.IdClinica;
                MedicoBuscado.CrmMedico = MedicoAtualizado.CrmMedico;
                MedicoBuscado.NomeMedico = MedicoAtualizado.NomeMedico;
            }

            ctx.Medicos.Update(MedicoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico MedicoBuscado = ListarId(idMedico);

            ctx.Medicos.Remove(MedicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos
                .Select(c => new Medico
                {
                    IdMedico = c.IdMedico,
                    IdUsuario = c.IdUsuario,
                    IdEspecialidadeMedico = c.IdEspecialidadeMedico,
                    IdClinica = c.IdClinica,
                    CrmMedico = c.CrmMedico,
                    NomeMedico = c.NomeMedico,
                    IdClinicaNavigation = new Clinica
                    {
                        EnderecoClinica = c.IdClinicaNavigation.EnderecoClinica,
                        HorarioInicio = c.IdClinicaNavigation.HorarioInicio,
                        HorarioFim = c.IdClinicaNavigation.HorarioFim,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        NomeFantasia = c.IdClinicaNavigation.NomeFantasia,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                    },
                    IdEspecialidadeMedicoNavigation = new EspecialidadeMedico
                    {
                        NomeEspecialidade = c.IdEspecialidadeMedicoNavigation.NomeEspecialidade,
                        DescricaoEspecialidade = c.IdEspecialidadeMedicoNavigation.DescricaoEspecialidade,
                    }
                }).ToList();
        }

        public List<Medico> ListarComConsultas()
        {
            return ctx.Medicos.Include(c => c.Consulta).OrderBy(c => c.IdMedico).ToList();
        }

        public Medico ListarId(int id)
        {
            return ctx.Medicos.FirstOrDefault(c => c.IdMedico == id);
        }
    }
}