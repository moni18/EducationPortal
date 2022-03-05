using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Hospital;

namespace BusinessLogic.Base
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientViewModel>> FetchAsync();
    }
}
