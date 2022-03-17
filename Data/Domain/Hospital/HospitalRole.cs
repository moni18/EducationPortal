using Microsoft.AspNetCore.Identity;

namespace Data.Domain.Hospital
{
    public class HospitalRole : IdentityRole
    {
        public bool IsRegister { get; set; }
    }
}
