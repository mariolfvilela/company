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

        public RepositoryBase(ContextCompany contexto)
            : base()
        {
            this._context = contexto;
        }

        public TEntity Add(TEntity entidade)
        {
            throw new NotImplementedException();
        }

        public void Alterar(TEntity entidade)
        {
            _context.InitTransacao();
            _context.Set<TEntity>().Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SendChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            var entidade = SelecionarPorId(id);
            if (entidade != null)
            {
                _context.InitTransacao();
                _context.Set<TEntity>().Remove(entidade);
                _context.SendChanges();
            }
        }

        public void Excluir(TEntity entidade)
        {
            _context.InitTransacao();
            _context.Set<TEntity>().Remove(entidade);
            _context.SendChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Incluir(TEntity entidade)
        {
            _context.InitTransacao();
            var id = _context.Set<TEntity>().Add(entidade).Entity.Id;
            _context.SendChanges();
            return id;
        }

        public void Remove(TEntity entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity SelecionarPorId(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> SelecionarTodos()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entidade)
        {
            throw new NotImplementedException();
        }
    }
}
