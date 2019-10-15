using System;
using Allianz.Application.ViewModels;
using Allianz.Domain.Entities;
using AutoMapper;

namespace Allianz.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
