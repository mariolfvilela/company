using System;
using System.Collections.Generic;
using Company.Application.ViewModels;
using Company.Domain.Common;

namespace Company.Application.Interfaces
{
    public interface IAppServiceBase<TEntityDomain, TEntityViewModel>
        where TEntityDomain : EntityBase
        where TEntityViewModel : ViewModelBase
    {
        TEntityViewModel add(TEntityViewModel entityViewModel);
        IEnumerable<TEntityViewModel> GetAll();
        TEntityViewModel GetById(Guid id);
        void Update(TEntityViewModel entityViewModel);
        void Remove(Guid id);
        IList<TEntityViewModel> GetAllHistory(Guid id);
    }
}
