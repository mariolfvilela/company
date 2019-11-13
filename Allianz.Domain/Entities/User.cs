using System;
using Company.Domain.Common;
using Company.Domain.Enums;

namespace Company.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
    }
}
