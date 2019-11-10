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
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
