using System.Collections.Generic;
using System.Linq;
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
        private readonly HospitalDbContext _dbContext;

        public PatientService(HospitalDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PatientViewModel>> FetchAsync()
        {
            return new List<PatientViewModel>();
            //return Mapper.Map<IEnumerable<PatientViewModel>>(await _dbContext.Users.Where(x=>x).ToListAsync()); TODO
        }
    }
}
