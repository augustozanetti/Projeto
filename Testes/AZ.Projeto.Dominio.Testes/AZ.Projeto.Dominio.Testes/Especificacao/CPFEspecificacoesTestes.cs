using AZ.Projeto.Dominio.Especificacoes.Clientes;
using AZ.Projeto.Dominio.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Testes.Especificacao
{
    [TestClass]
    public class CPFEspecificacoesTestes
    {
        [TestMethod]
        public void CPF_IsSatisfied_True()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "44023466816"
            };

            //ACT
            var spcReturn = new ClienteDeveTerCpfValidoEspecificacao().IsSatisfiedBy(cliente);

            //Assert
            Assert.IsTrue(spcReturn);
        }

        [TestMethod]
        public void CPF_IsSatisfied_False()
        {
            //Arrange
            var cliente = new Cliente
            {
                CPF = "12345678971"
            };

            //ACT
            var spcReturn = new ClienteDeveTerCpfValidoEspecificacao().IsSatisfiedBy(cliente);

            //Assert
            Assert.IsFalse(spcReturn);
        }

    }
}
