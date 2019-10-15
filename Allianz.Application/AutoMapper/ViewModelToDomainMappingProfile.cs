using System;
using Company.Application.ViewModels;
using Company.Domain.Entities;
using AutoMapper;

namespace Company.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
