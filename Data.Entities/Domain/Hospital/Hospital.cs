using System.Collections.Generic;
using Data.Entities.Domain.Base;

namespace Data.Entities.Domain.Hospital
{
    public class Hospital : NameKeyEntityBase<int>
    {
        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
