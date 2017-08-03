using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AZ.Projeto.Infra.Dados.Repositorios
{
    public abstract class Repository<TEntity> : IRepositorio<TEntity> where TEntity : Entity, new()
    {
        protected ProjetoContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository()
        {
            Db = new ProjetoContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            SaveChanges();

            return objReturn;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            //paginacao Skip/Take(pula e pega)
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)
        {
            //Evita realizar a busca no banco para deletar o objeto
            var obj = new TEntity { Id = id };
            DbSet.Remove(obj);
            SaveChanges();
            //DbSet.Remove(DbSet.Find(id));
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
