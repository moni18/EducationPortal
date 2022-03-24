
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Education;


namespace BusinessLogic.Base
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolViewModel>> FetchAsync();
        Task<SchoolViewModel> FetchAsync(int id);
        Task CreateAsync(SchoolViewModel school);
    }
}
