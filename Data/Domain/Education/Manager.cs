using System.Collections.Generic;
using Data.Domain.Identity;
using Data.Enums;

namespace Data.Domain.Education
{
    public class Manager
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<University> Universities { get; set; }

    }
}
