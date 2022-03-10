using System.Collections.Generic;
using Data.Domain.Hospital.Base;

namespace Data.Domain.Hospital
{
    public class Hospital : NameKeyEntityBase<int>
    {
        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
