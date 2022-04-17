using System.Collections.Generic;
using Data.Domain.Education;
using Microsoft.AspNetCore.Identity;

namespace Data.Domain.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Manager Manager { get; set; }
        public Student Student { get; set; }
        //public Pupil Pupil { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
