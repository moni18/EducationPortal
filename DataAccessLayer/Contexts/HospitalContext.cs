using System.Reflection;
using Data.Domain.Hospital;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class HospitalContext : DbContext
    {
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
