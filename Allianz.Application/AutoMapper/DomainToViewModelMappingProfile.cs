using System;
using Company.Application.ViewModels;
using Company.Domain.Entities;
using AutoMapper;

namespace Company.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
