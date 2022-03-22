using Data.Entities.Domain.Hospital;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configs.HospitalConfigs
{
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
