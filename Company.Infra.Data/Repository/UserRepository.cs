using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Domain.Entities;
using Company.Domain.Enums;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;

namespace Company.Infra.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ContextCompany contexto)
            : base(contexto)
        {
        }

        public async Task<User> Login(string username, string password)
        {
            return GetUser().Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password)
                .Select(x => { x.Password = ""; return x; })
                .FirstOrDefault();
        }

        private IEnumerable<User> GetUser()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Roles = Roles.Admin });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Roles = Roles.User });
            return users;            
        }
    }
}
