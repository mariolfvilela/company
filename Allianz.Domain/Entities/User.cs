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

        /// <summary>
        /// Description of Roles
        /// </summary>
        public string RolesDescription
        {
            get
            {
                switch (Roles)
                {
                    case Roles.Admin: return "Admin";
                    case Roles.User: return "User";
                    case Roles.None: return "None";
                    default: return string.Empty;
                }
            }
        }
    }
}
