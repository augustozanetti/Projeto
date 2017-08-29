using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Infra.Dados.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
