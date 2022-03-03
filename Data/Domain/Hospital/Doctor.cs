using System.Collections.Generic;

namespace Data.Domain.Hospital
{
    public class Doctor : User
    {
        public int HospitalId { get; set; }
        public int CabinetNumber { get; set; }

        public Hospital Hospital { get; set; }
        public ICollection<Reception> Receptions { get; set; }
    }
}
