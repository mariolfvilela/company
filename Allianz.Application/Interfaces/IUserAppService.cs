using System;
using System.Threading.Tasks;
using Company.Application.ViewModels;
using Company.Domain.Entities;

namespace Company.Application.Interfaces
{
    public interface IUserAppService : IAppServicoBase<User, UserViewModel>
    {
        Task<UserViewModel> Login(string username, string password);
    }
}
