using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
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
                CabinetNumber = x.Doctor.CabinetNumber,
                DateTime = x.DateTime,
                DoctorName = $"{x.Doctor.LastName} {x.Doctor.FirstName}"
            }).ToListAsync();
        }
    }
}
