using System.Collections.Generic;

namespace Data.Domain.Hospital
{
    public class Patient : User
    {
        public string Complaint { get; set; }
        public string Diagnosis { get; set; }

        public ICollection<Reception> Receptions { get; set; }
    }
}
