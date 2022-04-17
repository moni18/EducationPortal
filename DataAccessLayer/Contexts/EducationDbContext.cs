using System.Reflection;
using Data.Domain.Education;
using Data.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    /*
     * 8)	Образование. Список доступных школ и университетов и личная страница каждого.
     * Выдача роли, просмотр и поиск учеников, и возможность выдать сертификат.
     * Возможность выдать и забрать грант. Исключение ученика. Типы сертификатов: средний, высший, полицейский, военный.
     * Возможность оплаты учебы за счет родителей.
     */
    public class EducationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, 
        ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        //public DbSet<Pupil> Pupils { get; set; }


        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<University>().ToTable("Universities");
            modelBuilder.Entity<School>().ToTable("Schools");

            //modelBuilder.Entity<University>()
            //    .HasDiscriminator<string>("InstitutionType")
            //    .HasValue<University>("university")
            //    .HasValue<School>("school");
            //modelBuilder.Entity<University>()
            //    .Property("Discriminator")
            //    .HasMaxLength(200);

            //modelBuilder.Entity<University>()
            //    .HasDiscriminator(b => b.InstitutionType);

            //modelBuilder.Entity<University>()
            //    .Property(e => e.InstitutionType)
            //    .HasMaxLength(200)
            //    .HasColumnName("institution_type");
            //modelBuilder.Entity<University>()
            //    .HasDiscriminator()
            //    .IsComplete(false);


            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}

