using System;
using Allianz.Domain.Entities;

namespace Allianz.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetByEmail(string email);
    }
}
