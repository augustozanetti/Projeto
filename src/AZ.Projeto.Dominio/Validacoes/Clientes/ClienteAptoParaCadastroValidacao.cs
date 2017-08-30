using AZ.Projeto.Dominio.Especificacoes.Clientes;
using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Validacoes.Clientes
{
    public class ClienteAptoParaCadastroValidacao : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidacao(IClienteRepositorio clienteRepository)
        {
            var clienteUnico = new ClienteDeveSerUnicoEspecificacao(clienteRepository);

            base.Add("clienteUnico", new Rule<Cliente>(clienteUnico, "Cliente com CPF ou E-maill já cadastrado"));
        }
    }
}
