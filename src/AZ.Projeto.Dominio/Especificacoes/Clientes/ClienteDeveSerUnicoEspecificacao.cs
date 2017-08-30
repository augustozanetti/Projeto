using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Especificacoes.Clientes
{
    public class ClienteDeveSerUnicoEspecificacao : ISpecification<Cliente>
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteDeveSerUnicoEspecificacao(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepositorio.ObterPorCpf(cliente.CPF) == null &&
                   _clienteRepositorio.ObterPorEmail(cliente.Email) == null;
        }
    }
}
