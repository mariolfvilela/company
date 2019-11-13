using System;
using System.Threading.Tasks;
using Company.Domain.Entities;

namespace Company.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> Login(string username, string password);
    }
}
