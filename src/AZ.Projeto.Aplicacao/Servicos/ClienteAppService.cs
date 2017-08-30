using System;
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
using AZ.Projeto.Dominio.Interfaces.Servico;
using AZ.Projeto.Infra.Dados.Interfaces;

namespace AZ.Projeto.Aplicacao.Servicos
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteRepositorio _clienteRepository;
        private readonly IClienteServico _clienteService;

        public ClienteAppService(IClienteRepositorio clienteRepository, 
                                 IClienteServico clienteService,
                                 IUnitOfWork uow) : base (uow)                        
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.Enderecos.Add(endereco);
            //Add Pedido
            var clienteReturn = _clienteService.Adicionar(cliente);
            // Add ordem pagto
            // Add Log transação - Integração cartão


            //Validar se dominio não reclamou de nada.
            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            clienteEnderecoViewModel.Cliente = Mapper.Map<ClienteViewModel>(clienteReturn);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteReturn = _clienteService.Atualizar(cliente);

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
            _clienteService.Remover(id);
        }
    }
}
