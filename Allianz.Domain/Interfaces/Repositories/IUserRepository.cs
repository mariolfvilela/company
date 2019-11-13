using System;
using System.Threading.Tasks;
using Company.Domain.Entities;

namespace Company.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> Login(string username, string password);
    }
}
