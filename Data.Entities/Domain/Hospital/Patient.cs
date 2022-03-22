using System.Collections.Generic;
using Data.Entities.Domain.Identity;

namespace Data.Entities.Domain.Hospital
{
    public class Patient
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Address { get; set; }

        public ICollection<Reception> Receptions { get; set; }
    }
}
