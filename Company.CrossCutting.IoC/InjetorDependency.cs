using System;
using Company.Application.Interfaces;
using Company.Application.Services;
using Company.Domain.Interfaces.Repositories;
using Company.Domain.Interfaces.Services;
using Company.Domain.Services;
using Company.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Company.CrossCutting.IoC
{
    public class InjetorDependency
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddTransient(typeof(IAppServicoBase<,>), typeof(AppServiceBase<,>));
            svcCollection.AddTransient<ICustomerAppService, CustomerAppService>();

            svcCollection.AddTransient<IStarshipAppService, StarshipAppService>();

            //Domínio
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<ICustomerService, CustomerService>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            svcCollection.AddScoped<ICustomerRepository, CustomerRepository>();


            // https://balta.io/blog/aspnet-core-dependency-injection
            // AddScoped
            // AddTransient
        }
    }
}
