using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AZ.Projeto.Infra.Dados.Repositorios
{
    public abstract class Repository<TEntity> : IRepositorio<TEntity> where TEntity : Entity
    {
        protected ProjetoContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository()
        {
            Db = new ProjetoContext();
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            Db.SaveChanges();

            return objReturn;
        }

        public TEntity Atualizar(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public async Task ObterTodos(int t, int s)
        {
            var ret = await DbSet.ToListAsync();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
