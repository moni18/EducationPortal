using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.Hospital.Base;
using Data.Entities.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class PatientService : BaseService, IPatientService
    {
        private readonly HospitalDbContext _dbContext;

        public PatientService(HospitalDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PatientViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<PatientViewModel>>(await _dbContext.Patients.Include(x => x.User).ToListAsync());
        }
    }
}
