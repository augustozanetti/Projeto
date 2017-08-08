﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZ.Projeto.Aplicacao.Interfaces;
using AZ.Projeto.Aplicacao.ViewModels;
using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Infra.Dados.Repositorios;
using AutoMapper;
using AZ.Projeto.Dominio.Model;

namespace AZ.Projeto.Aplicacao.Servicos
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepositorio _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.Enderecos.Add(endereco);
            var clienteReturn = _clienteRepository.Adicionar(cliente);

            clienteEnderecoViewModel.Cliente = Mapper.Map<ClienteViewModel>(clienteReturn);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteReturn = _clienteRepository.Atualizar(cliente);

            return Mapper.Map<ClienteViewModel>(clienteReturn);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}