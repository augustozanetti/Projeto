using AZ.Projeto.Dominio.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Testes.Model
{
    [TestClass]
    public class ClienteTestes
    {
        //Padrão AAA -> Arrange(objeto referido), Act(ação), Assert(validação)

        [TestMethod]
        public void Cliente_EhValido_True()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "44023466816",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //ACT
            var result = cliente.EhValido();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EhValido_False()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "12345678971",
                Email = "",
                DataNascimento = DateTime.Now 
            };

            //ACT
            var result = cliente.EhValido();

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido"));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido"));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para cadastro"));
        }
    }
}
