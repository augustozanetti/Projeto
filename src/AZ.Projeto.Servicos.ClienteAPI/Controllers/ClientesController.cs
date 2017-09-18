using AZ.Projeto.Aplicacao.Interfaces;
using AZ.Projeto.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace AZ.Projeto.Servicos.ClienteAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _clienteAppService.ObterTodos();
        }

        [HttpGet]
        public ClienteViewModel ObterPorId(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        public HttpStatusCode Post([FromBody]ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);
            }

            if (clienteEnderecoViewModel.Cliente.ValidationResult.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }

            return HttpStatusCode.OK;
        }

        public void Put(Guid id, [FromBody]ClienteViewModel clienteViewModel)
        {
            _clienteAppService.Atualizar(clienteViewModel);
        }

        public void Delete(Guid id)
        {
            _clienteAppService.Remover(id);
        }
    }
}
