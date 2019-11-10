using System;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.Common;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Company.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly ContextCompany _context;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(ContextCompany contexto)
            : base()
        {
            _context = contexto;
            DbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Add(TEntity entidade)
        {
            _context.InitTransacao();
            entidade = DbSet.Add(entidade).Entity;
            _context.SendChanges();
             //DbSet.Add(entidade);
            return entidade;
        }

        public virtual void RemoveById(int id)
        {
            var entidade = GetById(id);
            if (entidade != null)
            {
                _context.InitTransacao();
                DbSet.Remove(entidade);
                _context.SendChanges();
            }
        }

        public virtual void Remove(TEntity entidade)
        {
            _context.InitTransacao();
            DbSet.Remove(entidade);
            _context.SendChanges();
        }

        public virtual TEntity Update(TEntity entidade)
        {
            _context.InitTransacao();
            DbSet.Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SendChanges();
            return entidade;
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
