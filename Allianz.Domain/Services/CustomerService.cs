using System;
using Company.Domain.Entities;
using Company.Domain.Interfaces.Repositories;
using Company.Domain.Interfaces.Services;

namespace Company.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }

        public Customer GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
