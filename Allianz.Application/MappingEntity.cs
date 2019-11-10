using System;
using AutoMapper;
using Company.Application.Interfaces;
using Company.Application.Services;
using Company.Domain.Services;
using Company.Domain.Interfaces.Services;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Repository;
using Company.Domain.Entities;
using Company.Application.ViewModels;

namespace Company.Application
{
    public class MappingEntity : Profile
    {
        public MappingEntity() {
            CreateMap<ICustomerAppService, CustomerAppService>();
            CreateMap<ICustomerService, CustomerService>();

            CreateMap<ICustomerRepository, CustomerRepository>();

            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer,CustomerViewModel> ();
        }
            //public static void Registrar(IServiceCollection svcCollection)
            //{
            //Aplicação
            //svcCollection.AddScoped(typeof(IAppServiceBase<,>), typeof(AppServiceBase<,>));
            //svcCollection.AddScoped<ICustomerAppService, CustomerAppService>();

            //Domínio
            //svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            //svcCollection.AddScoped<ICustomerService, CustomerService>();

            //Repositorio
            //svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //svcCollection.AddScoped<ICustomerRepository, CustomerRepository>();

            //CreateMap<Customer, CustomerViewModel>();
            //CreateMap<CustomerViewModel, Customer>();
        //}
    }
}
