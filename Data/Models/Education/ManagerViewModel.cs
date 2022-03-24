using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Education
{
    public class ManagerViewModel
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public ICollection<StudentViewModel> StudentList{ get; set; }
    }
}
