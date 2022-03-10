using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Base;
using Data.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class PatientService : BaseService, IPatientService
    {
        private readonly HospitalContext _dbContext;

        public PatientService(HospitalContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PatientViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<PatientViewModel>>(await _dbContext.Patients.ToListAsync());
        }
    }
}
