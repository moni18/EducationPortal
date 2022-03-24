using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Education
{
    public class Manager : User
    {
        public ICollection<School> Schools { get; set; }
    }
}
