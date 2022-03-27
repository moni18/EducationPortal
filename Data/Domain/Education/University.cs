using Data.Domain.Education.Base;
using System.Collections.Generic;


namespace Data.Domain.Education
{
    public class University : NameKeyEntityBase<int>
    {
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
