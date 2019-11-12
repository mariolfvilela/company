using System;
using AutoMapper;
using Company.Application.ViewModels;
using Company.Domain.Entities;

namespace Company.Application.AutoMapper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            // Application to Domain
            CreateMap<CustomerViewModel, Customer>();

            // Domain to Resource
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
