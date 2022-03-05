using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Hospital
{
    public class ReceptionViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        //[Range(1, 100, ErrorMessage = "Only positive number allowed")]
        public int CabinetNumber { get; set; }

        [Required(ErrorMessage = "Select doctor")]
        public int DoctorId { get; set; }
        public IEnumerable<DoctorViewModel> DoctorsList { get; set; }

        [Required(ErrorMessage = "Select patient")]
        public int PatientId { get; set; }
        public IEnumerable<PatientViewModel> PatientsList { get; set; }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
