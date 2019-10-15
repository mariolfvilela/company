using System;
using Allianz.Application.ViewModels;
using Allianz.Domain.Entities;
using AutoMapper;

namespace Allianz.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
