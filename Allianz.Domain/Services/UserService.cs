using System;
using System.Threading.Tasks;
using Company.Domain.Entities;
using Company.Domain.Interfaces.Repositories;
using Company.Domain.Interfaces.Services;

namespace Company.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        protected readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public async Task<User> Login(string username, string password)
        {
            return await _repository.Login(username, password);
        }
    }
}
