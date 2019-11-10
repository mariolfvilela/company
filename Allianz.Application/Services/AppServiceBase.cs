using System;
using System.Collections.Generic;
using AutoMapper;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Common;
using Company.Domain.Interfaces.Services;

namespace Company.Application.Services
{
    public class AppServiceBase<TEntity, TEntityViewModel> : IAppServicoBase<TEntity, TEntityViewModel>
        where TEntity : EntityBase
        where TEntityViewModel : ViewModelBase
    {
        protected readonly IServiceBase<TEntity> _service;
        protected readonly IMapper _mapper;

        public AppServiceBase(IMapper iMapper, IServiceBase<TEntity> servico)
            : base()
        {
            this._mapper = iMapper;
            this._service = servico;
        }

        public void Excluir(TEntityViewModel entidade)
        {
            _service.Excluir(_mapper.Map<TEntity>(entidade));
        }

        public IEnumerable<TEntityViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(_service.GetAll());
        }

        public TEntityViewModel GetById(int id)
        {
            return _mapper.Map<TEntityViewModel>(_service.GetById(id));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TEntityViewModel add(TEntityViewModel entityViewModel)
        {
            return _mapper.Map<TEntityViewModel>(_service.Add(_mapper.Map<TEntity>(entityViewModel)));
        }

        public TEntityViewModel Update(TEntityViewModel entityViewModel)
        {
            return _mapper.Map<TEntityViewModel>(_service.Update(_mapper.Map<TEntity>(entityViewModel)));
        }
    }
}
