using Data.Entities.Domain.Hospital;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configs.HospitalConfigs
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Address).HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Patient)
                .HasForeignKey<Patient>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
