using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Education
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Student> Students { get; set; }

    }
}
