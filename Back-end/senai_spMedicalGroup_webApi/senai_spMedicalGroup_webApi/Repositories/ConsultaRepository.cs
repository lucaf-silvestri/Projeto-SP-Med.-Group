using senai_spMedicalGroup_webApi.Contexts;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório das consultas.
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        /// <summary>
        /// Atualiza uma Consulta existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idConsulta">id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtualizada">Objeto ConsultaAtualizada com os novos dados</param>
        public void Atualizar(int idConsulta, Consultum ConsultaAtualizada)
        {
            Consultum ConsultaBuscada = ListarId(idConsulta);

            if (ConsultaBuscada != null)
            {
                ConsultaBuscada.IdCliente = ConsultaAtualizada.IdCliente;
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
                ConsultaBuscada.IdSituacao = ConsultaAtualizada.IdSituacao;
                ConsultaBuscada.DataConsulta = ConsultaAtualizada.DataConsulta;
                ConsultaBuscada.DescricaoConsulta = ConsultaAtualizada.DescricaoConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta com os novos dados</param>
        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="idConsulta">ID da Consulta deletada</param>
        public void Deletar(int idConsulta)
        {
            Consultum ConsultaBuscada = ListarId(idConsulta);

            ctx.Consulta.Remove(ConsultaBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Lista de consultas</returns>
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

        /// <summary>
        /// Busca uma Consulta através de seu ID
        /// </summary>
        /// <param name="id">ID da Consulta buscada</param>
        /// <returns>A Consulta buscada</returns>
        public Consultum ListarId(int id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        /// <summary>
        /// Lista as consultas ligadas a um usuário específico
        /// </summary>
        /// <param name="idUsuario">Id do usuário que terá as consultas listadas</param>
        /// <returns>Lista de consultas</returns>
        public List<Consultum> ListarEspecifico(int idUsuario)
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
                        EnderecoCliente = c.IdClienteNavigation.EnderecoCliente,

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdClienteNavigation.IdUsuarioNavigation.IdUsuario
                        }
                    },

                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        CrmMedico = c.IdMedicoNavigation.CrmMedico,
                        IdClinica = c.IdMedicoNavigation.IdClinica,
                        IdEspecialidadeMedicoNavigation = new EspecialidadeMedico
                        {
                            NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeMedicoNavigation.NomeEspecialidade
                        },

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario
                        }
                    },

                    IdSituacaoNavigation = new Situacao
                    {
                        TipoSituacao = c.IdSituacaoNavigation.TipoSituacao
                    }
                })
                .Where(c => c.IdClienteNavigation.IdUsuarioNavigation.IdUsuario == idUsuario || c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario == idUsuario).ToList();
        }

        /// <summary>
        /// Adiciona descrição a uma consulta existente
        /// </summary>
        /// <param name="idConsulta">Id da consulta que terá a descrição adicionada</param>
        /// <param name="ConsultaDescricao">objeto com atributo descrição</param>
        public void AdicionarDecricao(int idConsulta, Consultum ConsultaDescricao)
        {
            Consultum ConsultaBuscada = ListarId(idConsulta);

            if (ConsultaDescricao.DescricaoConsulta != null)
            {
                ConsultaBuscada.DescricaoConsulta = ConsultaDescricao.DescricaoConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }
    }
}