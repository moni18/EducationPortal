using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Base;
using Data.Models.Education;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Education
{
    public class ManagerService : BaseService, IManagerService
    {
        private readonly EducationDbContext _dbContext;
        public ManagerService(EducationDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ManagerViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<ManagerViewModel>>(await _dbContext.Managers.ToListAsync());
        }
    }
}
