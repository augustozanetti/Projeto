using AZ.Projeto.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Interfaces.Repositorio
{
    //Qualquer tipo de entidade desde que seja uma Entity ou seja tenha herdado de Entity
    //Onde TEntity for herança de Entity
    public interface IRepositorio<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        Task ObterTodos();

        TEntity Atualizar(TEntity obj);

        void Remover(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
