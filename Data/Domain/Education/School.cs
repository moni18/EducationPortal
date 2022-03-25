using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Education.Base;

namespace Data.Domain.Education
{
    public class School : NameKeyEntityBase<int>
    {
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Student> Students { get; set; }

    }
}
