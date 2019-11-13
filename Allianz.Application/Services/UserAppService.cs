using System;
using System.Threading.Tasks;
using AutoMapper;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Entities;
using Company.Domain.Interfaces.Services;

namespace Company.Application.Services
{
    public class UserAppService : AppServiceBase<User, UserViewModel>, IUserAppService
    {
        protected readonly IUserService _service;

        public UserAppService(IMapper iMapper, IUserService service)
            : base(iMapper, service)
        {
            _service = service;
        }

        public async Task<UserViewModel> Login(string username, string password)
        {
            return _mapper.Map<UserViewModel>(await _service.Login(username, password));
        }
    }
}
