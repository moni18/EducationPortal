using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Hospital;

namespace BusinessLogic.Base
{
    public interface IReceptionService
    {
        Task<IEnumerable<ReceptionViewModel>> FetchAsync();
    }
}
