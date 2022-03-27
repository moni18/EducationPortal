using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Education;


namespace BusinessLogic.Base
{
    public interface IUniversityService
    {
        Task<IEnumerable<UniversityViewModel>> FetchAsync();
        Task<UniversityViewModel> FetchAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(UniversityViewModel school);
        Task CreateAsync(UniversityViewModel school);
    }
}