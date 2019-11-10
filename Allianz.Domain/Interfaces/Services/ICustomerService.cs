using System;
using Company.Domain.Entities;

namespace Company.Domain.Interfaces.Services
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        Customer GetByEmail(string email);
    }
}
