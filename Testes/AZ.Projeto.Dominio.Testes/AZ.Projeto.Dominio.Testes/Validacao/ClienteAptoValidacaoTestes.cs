using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Dominio.Validacoes.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Testes.Validacao
{
    [TestClass]
    public class ClienteAptoValidacaoTestes
    {
        [TestMethod]
        public void ClienteApto_IsValid_True()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "12345678971",
                Email = "teste@teste.com"
            };

            //ACT
            //Mock -> criar um objeto com a especificação já desenvolvida, se passa por um objeto
            //repostas prontas para métodos que usam o banco de dados
            //RhinoMocks ou Moqil
            //Mock - Apenas representa o objeto
            //Stub - Vicia os métodos para poder retornar algo pré programado
            var repository = MockRepository.GenerateStub<IClienteRepositorio>();
            repository.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);
            repository.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);
            var validationReturn = new ClienteAptoParaCadastroValidacao(repository).Validate(cliente);

            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void ClienteApto_IsValid_False()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "12345678971",
                Email = "teste@teste.com"
            };

            //ACT
            //Mock -> criar um objeto com a especificação já desenvolvida, se passa por um objeto
            //repostas prontas para métodos que usam o banco de dados
            //RhinoMocks ou Moqil
            //Mock - Apenas representa o objeto
            //Stub - Vicia os métodos para poder retornar algo pré programado
            var repository = MockRepository.GenerateStub<IClienteRepositorio>();
            repository.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);
            repository.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);
            var validationReturn = new ClienteAptoParaCadastroValidacao(repository).Validate(cliente);

            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "Cliente com CPF ou E-maill já cadastrado"));
        }
    }
}
