using Data.Domain.Education;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class EducationDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {
        }
    }
}
