using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Dominio.ObjetosValor;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Especificacoes.Clientes
{
    public class ClienteDeveTerEmailValidoEspecificacao : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return Email.Validar(cliente.Email);
        }
    }
}
