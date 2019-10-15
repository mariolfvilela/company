using System;
using System.Collections.Generic;
using Allianz.Application.ViewModels;
using Allianz.Domain.Interfaces.Repositories;
using AutoMapper;

namespace Allianz.Application.Services
{
    public class CustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        

        public CustomerViewModel GetById(int id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
