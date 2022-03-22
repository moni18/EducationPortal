using System.Collections.Generic;
using Data.Entities.Domain.Identity;

namespace Data.Entities.Domain.Hospital
{
    public class Doctor
    {
        public int HospitalId { get; set; }
        public int CabinetNumber { get; set; }
        public string Specialization { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Hospital Hospital { get; set; }
        public ICollection<Reception> Receptions { get; set; }
    }
}
