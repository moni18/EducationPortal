using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class HospitalService : BaseService
    {
        private readonly HospitalDbContext _dbContext;

        public HospitalService(HospitalDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<HospitalViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<HospitalViewModel>>(await _dbContext.Hospitals.ToListAsync());
        }
    }
}
