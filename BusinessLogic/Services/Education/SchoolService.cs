using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Domain.Education;
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
                ManagerName = $"{x.Manager.FirstName} {x.Manager.LastName}",
                StudentsNumber = x.Students.Count()
            }).ToListAsync();
        }

        public async Task<SchoolViewModel> FetchAsync(int id)
        {
            var school = await _dbContext.Schools
                .Include(x => x.Manager)
                .Include(x=>x.Students)
                .SingleOrDefaultAsync(x => x.Id == id);
            return new SchoolViewModel
            {
                Id = school.Id,
                Name = school.Name,
                Address = school.Address,
                ManagerName = $"{school.Manager.FirstName} {school.Manager.LastName}",
                StudentsNumber = school.Students.Count()
            };
        }

        public async Task CreateAsync(SchoolViewModel school)
        {
            await _dbContext.Schools.AddAsync(new School
            {
                Name = school.Name,
                Address = school.Address,
                ManagerId = school.ManagerId
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
