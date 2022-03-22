using System.Collections.Generic;
using Data.Entities.Domain.Hospital;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
