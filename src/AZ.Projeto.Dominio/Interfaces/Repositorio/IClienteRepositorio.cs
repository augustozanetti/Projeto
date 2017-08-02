using AZ.Projeto.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Interfaces.Repositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}
