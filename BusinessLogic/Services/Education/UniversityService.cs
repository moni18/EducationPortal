using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Domain.Education;
using Data.Models.Education;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Education
{
    public class UniversityService : BaseService
    {
        private readonly EducationDbContext _dbContext;
        public UniversityService(EducationDbContext dbContext, IMapper mapper):base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UniversityViewModel>> FetchAsync()
        {
            var items = await _dbContext.Universities
                .Include(x => x.Manager)
                .Include(x=>x.Students).ToListAsync();
            return Mapper.Map<IEnumerable<UniversityViewModel>>(items);
           
        }

        public async Task<UniversityViewModel> FetchAsync(int id)
        {
            var university = await _dbContext.Universities
                .Include(x => x.Manager)
                .Include(x=>x.Students)
                .SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<UniversityViewModel>(university);
        }

        public async Task DeleteAsync(int id)
        {
            var university = await _dbContext.Universities
                .SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Universities.Remove(university);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UniversityViewModel university)
        {
            var item = await _dbContext.Universities
                .SingleOrDefaultAsync(x => x.Id == university.Id);
            item.Name = university.Name;
            item.Address = university.Address;
            item.ManagerId = university.ManagerId;


            _dbContext.Universities.Update(item);
            await _dbContext.SaveChangesAsync();

        }

        public async Task CreateAsync(UniversityViewModel university)
        {
            await _dbContext.Universities.AddAsync(Mapper.Map<University>(university));

            await _dbContext.SaveChangesAsync();
        }
    }
}
