using System;
using System.Collections.Generic;
using Allianz.Application.ViewModels;

namespace Allianz.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
    }
}
