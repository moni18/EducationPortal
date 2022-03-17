using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Data.Domain.Hospital
{
    public class HospitalUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
