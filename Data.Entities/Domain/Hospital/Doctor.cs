using System.Collections.Generic;
using Data.Entities.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Domain.Hospital
{
    public class Doctor
    {
        public int HospitalId { get; set; }
        public int CabinetNumber { get; set; }
        public string Specialization { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Hospital Hospital { get; set; }
        public ICollection<Reception> Receptions { get; set; }
        public ICollection<DoctorSchedule> Schedules { get; set; }
    }

    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.HospitalId);
            builder.Property(x => x.CabinetNumber);
            builder.Property(x => x.Specialization).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(x => x.Doctor)
                .HasForeignKey<Doctor>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Doctors)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
