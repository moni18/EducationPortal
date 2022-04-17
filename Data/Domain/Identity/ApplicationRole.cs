using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Data.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsRegister { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
