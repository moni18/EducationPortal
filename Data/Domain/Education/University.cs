using System.Collections.Generic;
using Data.Domain.Base;
using Data.Enums;


namespace Data.Domain.Education
{
    public class University : NameKeyEntityBase<int>
    {
        public string Address { get; set; }
        public string ManagerId { get; set; }
        public Manager Manager { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}                                                       