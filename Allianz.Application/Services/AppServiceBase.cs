using System;
using System.Collections.Generic;
using AutoMapper;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Common;
using Company.Domain.Interfaces.Services;

namespace Company.Application.Services
{
    public class AppServiceBase<TEntity, TEntityViewModel> : ICustomerAppService<TEntity, TEntityViewModel>
        where TEntity : EntityBase
        where TEntityViewModel : ViewModelBase
    {
        protected readonly IServiceBase<TEntity> _service;
        protected readonly IMapper iMapper;

        public AppServiceBase(IMapper iMapper, IServiceBase<TEntity> servico)
            : base()
        {
            this.iMapper = iMapper;
            this._service = servico;
        }

        public void Alterar(TEntityViewModel entidade)
        {
            _service.Update(iMapper.Map<TEntity>(entidade));
        }

        public void Excluir(int id)
        {
            _service.Remove(id);
        }

        public void Excluir(TEntityViewModel entidade)
        {
            _service.Excluir(iMapper.Map<TEntity>(entidade));
        }

        public IEnumerable<TEntityViewModel> GetAll()
        {
            return iMapper.Map<IEnumerable<TEntityViewModel>>(_service.GetAll());
        }

        public IList<TEntityViewModel> GetAllHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntityViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Incluir(TEntityViewModel entidade)
        {
            throw new NotImplementedException();
            // return _service.Excluir(iMapper.Map<TEntity>(entidade));
        }

        public TEntityViewModel add(TEntityViewModel entityViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntityViewModel SelecionarPorId(int id)
        {
            throw new NotImplementedException();
            //return iMapper.Map<TEntityViewModel>(_service.SelecionarPorId(id));
        }

        public IEnumerable<TEntityViewModel> SelecionarTodos()
        {
            throw new NotImplementedException();
            //return iMapper.Map<IEnumerable<TEntityViewModel>>(_service.SelecionarTodos());
        }

        public void Update(TEntityViewModel entityViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
