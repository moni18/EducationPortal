using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Education
{
    public class Student : User
    {
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
