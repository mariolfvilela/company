using System;
using System.Collections.Generic;
using Allianz.Application.ViewModels;
using Company.Application.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Interfaces
{
    public interface ICustomerAppService : IAppServicoBase<Customer, CustomerViewModel>
    {
    }
}
