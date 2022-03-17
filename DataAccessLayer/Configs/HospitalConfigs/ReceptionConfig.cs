using Data.Domain.Hospital;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configs.HospitalConfigs
{
    public class ReceptionConfig : IEntityTypeConfiguration<Reception>
    {
        public void Configure(EntityTypeBuilder<Reception> builder)
        {
            builder.ToTable("Receptions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DateTime).IsRequired();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.Property(x => x.PatientId).IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Receptions)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
