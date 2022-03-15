using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Country { get; set; }
    }

    public class SportDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public SportDbContext(DbContextOptions<SportDbContext> options) : base(options)
        {
        }
    }
}
