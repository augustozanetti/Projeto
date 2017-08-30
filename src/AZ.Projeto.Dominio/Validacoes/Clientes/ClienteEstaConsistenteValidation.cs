using AZ.Projeto.Dominio.Especificacoes.Clientes;
using AZ.Projeto.Dominio.Model;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Validacoes.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoEspecificacao();
            var clienteEmail = new ClienteDeveTerEmailValidoEspecificacao();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeEspecificacao();

            base.Add("CPFClienteValido", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido"));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido"));
            base.Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro"));
        }
    }
}
