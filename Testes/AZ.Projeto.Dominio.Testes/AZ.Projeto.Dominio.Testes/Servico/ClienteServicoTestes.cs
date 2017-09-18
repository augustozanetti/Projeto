using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace AZ.Projeto.Dominio.Testes.Servico
{
    [TestClass]
    public class ClienteServicoTestes
    {
        [TestMethod]
        public void ClienteService_ObterClienteAtivo_Cliente()
        {
            //Arrange
            var cliente = new Cliente
            {
                Ativo = true,
                Excluido = false
            };

            var id = Guid.NewGuid();
            var repo = MockRepository.GenerateStub<IClienteRepositorio>();
            repo.Stub(s => s.ObterPorId(id)).Return(cliente);

            //ACT
            var clienteReturn = repo.ObterPorId(id);

            //Assert
            Assert.IsTrue(clienteReturn.EhAtivo());
        }
    }
}
