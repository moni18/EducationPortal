using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalContext _dbContext;

        public DoctorService(HospitalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DoctorViewModel>> FetchAsync()
        {
            return await _dbContext.Doctors.Select(x => new DoctorViewModel
            {
                Id = x.Id,
                Hospital = x.Hospital.Name,
                CabinetNumber = x.CabinetNumber,
                Name = $"{x.LastName} {x.FirstName}"
            }).ToListAsync();
        }
    }
}
