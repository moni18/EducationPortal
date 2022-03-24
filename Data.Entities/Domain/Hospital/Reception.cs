using System;
using Data.Entities.Domain.Base;

namespace Data.Entities.Domain.Hospital
{
    public class Reception : IdKeyEntityBase<int>
    {
        public DateTime DateTime { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public bool IsCompleted { get; set; }
        public string Treatment { get; set; }
        public string Complaint { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
