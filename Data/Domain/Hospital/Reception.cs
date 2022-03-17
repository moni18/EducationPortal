using System;
using Data.Domain.Hospital.Base;
using Microsoft.AspNetCore.Identity;

namespace Data.Domain.Hospital
{
    public class Reception : IdKeyEntityBase<int>
    {
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public string PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public IdentityUser Patient { get; set; }
    }
}
