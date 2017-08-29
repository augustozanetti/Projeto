using AZ.Projeto.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Dominio.Interfaces.Repositorio;

namespace AZ.Projeto.Dominio.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            return _clienteRepositorio.Atualizar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepositorio.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepositorio.Dispose();
        }
    }
}
