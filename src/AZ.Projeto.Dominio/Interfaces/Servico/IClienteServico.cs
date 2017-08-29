using AZ.Projeto.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Interfaces.Servico
{
    public interface IClienteServico : IDisposable
    {
        Cliente Adicionar(Cliente cliente);

        Cliente Atualizar(Cliente cliente);

        void Remover(Guid id);
    }
}
