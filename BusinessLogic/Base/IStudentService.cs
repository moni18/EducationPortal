using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Education;

namespace BusinessLogic.Base
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> FetchAsync();
    }
}
