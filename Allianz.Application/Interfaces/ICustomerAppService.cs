using Company.Application.ViewModels;
using Company.Domain.Entities;

namespace Company.Application.Interfaces
{
    public interface ICustomerAppService : ICustomerAppService<Customer, CustomerViewModel>
    {
    }
}
