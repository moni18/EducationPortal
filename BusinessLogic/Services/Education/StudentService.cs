using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Base;
using Data.Models.Education;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;


namespace BusinessLogic.Services.Education
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly EducationDbContext _dbContext;
        public StudentService(EducationDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<StudentViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<StudentViewModel>>(await _dbContext.Students.Include(x=>x.School).ToListAsync());
        }

    }
}
