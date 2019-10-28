using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Domain.Common;
using Company.Domain.Interfaces.Repositories;
using Company.Domain.Interfaces.Services;

namespace Company.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity entidade)
        {
            return _repository.Add(entidade);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Excluir(TEntity entidade)
        {
            _repository.Remove(entidade);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _repository.RemoveById(id);
        }

        public TEntity Update(TEntity entidade)
        {
            return _repository.Update(entidade);
        }
    }
}
