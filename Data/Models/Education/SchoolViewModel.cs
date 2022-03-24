using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Education
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public IEnumerable<StudentViewModel> StudentList { get; set; }
        public IEnumerable<ManagerViewModel> ManagerList { get; set; }
        public int StudentsNumber { get; set; }
    }
}
