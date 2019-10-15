using System;
using System.Collections.Generic;

namespace Company.Application.Interfaces
{
    public interface IAppServicoBase<TEntityDomain, TEntityViewModel>
        where TEntityDomain : class
        where TEntityViewModel : class
    {
        void Register(TEntityViewModel customerViewModel);
        IEnumerable<TEntityViewModel> GetAll();
        TEntityViewModel GetById(Guid id);
        void Update(TEntityViewModel customerViewModel);
        void Remove(Guid id);
        IList<TEntityViewModel> GetAllHistory(Guid id);
    }
}
