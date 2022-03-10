using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Base;
using Data.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class DoctorService : BaseService, IDoctorService
    {
        private readonly HospitalContext _dbContext;

        public DoctorService(HospitalContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DoctorViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<DoctorViewModel>>(await _dbContext.Doctors.Include(x => x.Hospital).ToListAsync());
        }
    }
}
