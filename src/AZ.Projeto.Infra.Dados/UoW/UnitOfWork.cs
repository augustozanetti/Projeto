using AZ.Projeto.Infra.Dados.Contexto;
using AZ.Projeto.Infra.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Infra.Dados.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoContext _projetoContext;

        public UnitOfWork(ProjetoContext projetoContext)
        {
            _projetoContext = projetoContext;
        }

        public void Commit()
        {
            _projetoContext.SaveChanges();
        }
    }
}
