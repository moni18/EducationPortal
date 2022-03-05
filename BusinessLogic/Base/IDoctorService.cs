using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Hospital;

namespace BusinessLogic.Base
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorViewModel>> FetchAsync();
    }
}
