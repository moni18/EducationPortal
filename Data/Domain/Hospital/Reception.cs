using System;

namespace Data.Domain.Hospital
{
    public class Reception
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
