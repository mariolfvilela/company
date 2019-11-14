using System;
using System.Collections.Generic;
using Company.Application.ViewModels;
using Company.Domain.Interfaces.Repositories;
using AutoMapper;
using Company.Domain.Common;
using Company.Application.Interfaces;
using Company.Domain.Interfaces.Services;
using Company.Domain.Entities;
using DotNetCore.Objects;
using System.Threading.Tasks;
using Company.Application.Validation;

namespace Company.Application.Services
{
    public class CustomerAppService : AppServiceBase<Customer, CustomerViewModel>, ICustomerAppService
    {

        public CustomerAppService(IMapper iMapper, ICustomerService service)
            : base(iMapper, service)
        {
        }

        public async Task<IDataResult<int>> AddAsync(CustomerViewModel entityViewModel)
        {
            IResult validation = new CustomerViewModelValidator().Validate(entityViewModel);

            if (validation.IsError)
            {
                return DataResult<int>.Error(validation.Message);
            }

            return await base.AddAsync(entityViewModel);
        }
    }
}
