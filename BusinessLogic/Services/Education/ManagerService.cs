using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Education;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Education
{
    public class ManagerService : IManagerService
    {
        private readonly EducationDbContext _dbContext;
        public ManagerService(EducationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ManagerViewModel>> FetchAsync()
        {
            return await _dbContext.Managers.Select(x => new ManagerViewModel
            {
                Id = x.Id,
                Name = $"{x.FirstName} {x.LastName}"
            }).ToListAsync();
        }
    }
}
