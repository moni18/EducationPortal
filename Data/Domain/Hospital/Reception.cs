using System;
using Data.Domain.Hospital.Base;

namespace Data.Domain.Hospital
{
    public class Reception : IdKeyEntityBase<int>
    {
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
