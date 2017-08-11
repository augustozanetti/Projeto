using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AZ.Projeto.Aplicacao.ViewModels;
using AZ.Projeto.Site.Models;
using AZ.Projeto.Aplicacao.Interfaces;
using AZ.Projeto.Aplicacao.Servicos;
using AZ.Projeto.Infra.CrossCutting.MvcFilters;

namespace AZ.Projeto.Site.Controllers
{
    [Authorize]
    [RoutePrefix("gestao/crm")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        [Route("listar-clientes")]
        [ClaimsAuthorize("Cliente", "LT")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [Route("{id:guid}/detalhe-cliente")]
        [ClaimsAuthorize("Cliente", "VI")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteViewModel);
        }

        [Route("novo-cliente")]
        [ClaimsAuthorize("Cliente", "IN")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo-cliente")]
        [ClaimsAuthorize("Cliente", "IN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Cliente", "EX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Cliente", "EX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
