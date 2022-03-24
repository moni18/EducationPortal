using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities.Models.Hospital;

namespace BusinessLogic.Services.Hospital.Base
{
    public interface IReceptionService
    {
        Task<IEnumerable<ReceptionViewModel>> FetchAsync();
        Task<IEnumerable<ReceptionViewModel>> FetchAsync(string userId);
        Task<ReceptionViewModel> FetchAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(ReceptionViewModel reception);
        Task CreateAsync(ReceptionViewModel reception);
        Task CloseAsync(int id);
    }
}
