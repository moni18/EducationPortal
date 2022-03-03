using System.Collections.Generic;

namespace Data.Domain.Hospital
{
    public class Patient : User
    {
        public ICollection<Reception> Receptions { get; set; }
    }
}
