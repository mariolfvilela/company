using System;
using Company.Domain.Entities;

namespace Company.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetByEmail(string email);
    }
}
