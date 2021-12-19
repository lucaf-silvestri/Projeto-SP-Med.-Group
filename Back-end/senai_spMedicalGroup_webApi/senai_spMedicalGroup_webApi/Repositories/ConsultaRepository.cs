using senai_spMedicalGroup_webApi.Contexts;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idConsulta, Consultum ConsultaAtualizado)
        {
            Consultum ConsultaBuscado = ListarId(idConsulta);

            if (ConsultaBuscado != null)
            {
                ConsultaBuscado.IdCliente = ConsultaAtualizado.IdCliente;
                ConsultaBuscado.IdMedico = ConsultaAtualizado.IdMedico;
                ConsultaBuscado.IdSituacao = ConsultaAtualizado.IdSituacao;
                ConsultaBuscado.DataConsulta = ConsultaAtualizado.DataConsulta;
                ConsultaBuscado.DescricaoConsulta = ConsultaAtualizado.DescricaoConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Consultum novoConsulta)
        {
            ctx.Consulta.Add(novoConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consultum ConsultaBuscado = ListarId(idConsulta);

            ctx.Consulta.Remove(ConsultaBuscado);

            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta
                .Select(c => new Consultum
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    DescricaoConsulta = c.DescricaoConsulta,
                    IdClienteNavigation = new Cliente
                    {
                        NomeCliente = c.IdClienteNavigation.NomeCliente,
                        DataNascCliente = c.IdClienteNavigation.DataNascCliente,
                        TelefoneCliente = c.IdClienteNavigation.TelefoneCliente,
                        RgCliente = c.IdClienteNavigation.RgCliente,
                        CpfCliente = c.IdClienteNavigation.CpfCliente,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        CrmMedico = c.IdMedicoNavigation.CrmMedico,
                        IdEspecialidadeMedicoNavigation = new EspecialidadeMedico
                        {
                            NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeMedicoNavigation.NomeEspecialidade
                        },
                    },
                    IdSituacaoNavigation = new Situacao
                    {
                        TipoSituacao = c.IdSituacaoNavigation.TipoSituacao
                    }
                }).ToList();
        }

        public Consultum ListarId(int id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }
    }
}