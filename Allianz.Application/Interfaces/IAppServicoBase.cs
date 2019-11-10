using System;
using System.Collections.Generic;
using Company.Application.ViewModels;
using Company.Domain.Common;

namespace Company.Application.Interfaces
{
    public interface IAppServicoBase<TEntity, TEntityViewModel>
        where TEntity : EntityBase
        where TEntityViewModel : ViewModelBase
    {
        TEntityViewModel add(TEntityViewModel entityViewModel);
        IEnumerable<TEntityViewModel> GetAll();
        TEntityViewModel GetById(int id);
        TEntityViewModel Update(TEntityViewModel entityViewModel);
        void Remove(int id);
    }
}
