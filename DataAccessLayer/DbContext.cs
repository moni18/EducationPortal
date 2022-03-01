using Data.Domain.Hospital;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class HospitalContext : DbContext
    {
        public DbSet<Reception> Receptions { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }
    }
}
