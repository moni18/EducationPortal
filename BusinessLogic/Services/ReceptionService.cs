using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Hospital;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly HospitalContext _dbContext;

        public ReceptionService(HospitalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReceptionViewModel>> FetchAsync()
        {
            return await _dbContext.Receptions.Select(x => new ReceptionViewModel
            {
                Id = x.Id,
                CabinetNumber = x.CabinetNumber,
                DateTime = x.DateTime
            }).ToListAsync();
        }
    }
}
