using System;
using Data.Entities.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Domain.Hospital
{
    public class Reception : IdKeyEntityBase<int>
    {
        public DateTime DateTime { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public bool IsCompleted { get; set; }
        public string Treatment { get; set; }
        public string Complaint { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }

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
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Receptions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
