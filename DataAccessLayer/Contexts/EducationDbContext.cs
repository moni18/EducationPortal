using System.Reflection;
using Data.Domain.Education;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class EducationDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //typeof(EducationDbContext).Assembly
            //Assembly.GetExecutingAssembly()
        }
    }
}
