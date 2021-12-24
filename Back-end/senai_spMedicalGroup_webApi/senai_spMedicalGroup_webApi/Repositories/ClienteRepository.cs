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
    public class ClienteRepository : IClienteRepository
    {
        spMedicalGroupContext ctx = new spMedicalGroupContext();

        public void Atualizar(int idCliente, Cliente ClienteAtualizado)
        {
            Cliente ClienteBuscado = ListarId(idCliente);

            if (ClienteBuscado != null)
            {
                ClienteBuscado.IdUsuario = ClienteAtualizado.IdUsuario;
                ClienteBuscado.NomeCliente = ClienteAtualizado.NomeCliente;
                ClienteBuscado.DataNascCliente = ClienteAtualizado.DataNascCliente;
                ClienteBuscado.TelefoneCliente = ClienteAtualizado.TelefoneCliente;
                ClienteBuscado.RgCliente = ClienteAtualizado.RgCliente;
                ClienteBuscado.CpfCliente = ClienteAtualizado.CpfCliente;
                ClienteBuscado.EnderecoCliente = ClienteAtualizado.EnderecoCliente;
            }

            ctx.Clientes.Update(ClienteBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Cliente novoCliente)
        {
            ctx.Clientes.Add(novoCliente);

            ctx.SaveChanges();
        }

        public void Deletar(int idCliente)
        {
            Cliente ClienteBuscado = ListarId(idCliente);

            ctx.Clientes.Remove(ClienteBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Clientes
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> Listar()
        {
            return ctx.Clientes
                .Select(c => new Cliente
                {
                    IdCliente = c.IdCliente,
                    IdUsuario = c.IdUsuario,
                    NomeCliente = c.NomeCliente,
                    DataNascCliente = c.DataNascCliente,
                    TelefoneCliente = c.TelefoneCliente,
                    RgCliente = c.RgCliente,
                    CpfCliente = c.CpfCliente,
                    EnderecoCliente = c.EnderecoCliente,

                    IdUsuarioNavigation = new Usuario
                    {
                        Email = c.IdUsuarioNavigation.Email,
                        Senha = c.IdUsuarioNavigation.Senha,
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario
                    }
                }).ToList();
        }

        public List<Cliente> ListarComConsultas()
        {
            return ctx.Clientes.Include(c => c.Consulta).OrderBy(c => c.IdCliente).ToList();
        }

        public Cliente ListarId(int id)
        {
            return ctx.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }
    }
}
