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
    public class ClienteDeveTerCpfValidoEspecificacao : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPF.Validar(cliente.CPF);
        }
    }
}
