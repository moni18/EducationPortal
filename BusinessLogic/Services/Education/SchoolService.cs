using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Education;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Education
{
    public class SchoolService : ISchoolService
    {
        private readonly EducationDbContext _dbContext;
        public SchoolService(EducationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SchoolViewModel>> FetchAsync()
        {
            return await _dbContext.Schools.Select(x => new SchoolViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                ManagerName = $"{x.Manager.FirstName} {x.Manager.LastName}"
            }).ToListAsync();
        }
    }
}
