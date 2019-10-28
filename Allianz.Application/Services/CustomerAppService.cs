using System;
using System.Collections.Generic;
using Company.Application.ViewModels;
using Company.Domain.Interfaces.Repositories;
using AutoMapper;
using Company.Domain.Common;
using Company.Application.Interfaces;
using Company.Domain.Interfaces.Services;
using Company.Domain.Entities;

namespace Company.Application.Services
{
    public class CustomerAppService : AppServiceBase<Customer, CustomerViewModel>, ICustomerAppService
    {

        public CustomerAppService(IMapper iMapper, ICustomerService service)
            : base(iMapper, service)
        {
        }
    }
}
