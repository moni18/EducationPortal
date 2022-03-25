using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Base;
using Data.Domain.Education;
using Data.Models.Education;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Education
{
    public class SchoolService : BaseService, ISchoolService
    {
        private readonly EducationDbContext _dbContext;
        public SchoolService(EducationDbContext dbContext, IMapper mapper):base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SchoolViewModel>> FetchAsync()
        {
            var items = await _dbContext.Schools
                .Include(x => x.Manager)
                .Include(x=>x.Students).ToListAsync();
            return Mapper.Map<IEnumerable<SchoolViewModel>>(items);
        }

        public async Task<SchoolViewModel> FetchAsync(int id)
        {
            var school = await _dbContext.Schools
                .Include(x => x.Manager)
                .Include(x=>x.Students)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<SchoolViewModel>(school);
        }

        public async Task DeleteAsync(int id)
        {
            var school = await _dbContext.Schools
                .SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Schools.Remove(school);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SchoolViewModel school)
        {
            var item = await _dbContext.Schools
                .SingleOrDefaultAsync(x => x.Id == school.Id);
            item.Name = school.Name;
            item.Address = school.Address;
            

            _dbContext.Schools.Update(item);
            await _dbContext.SaveChangesAsync();

        }

        public async Task CreateAsync(SchoolViewModel school)
        {
            await _dbContext.Schools.AddAsync(Mapper.Map<School>(school));

            await _dbContext.SaveChangesAsync();
        }
    }
}
