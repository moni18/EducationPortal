using System.Collections.Generic;
using Data.Entities.Domain.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Domain.Hospital
{
    public class Patient
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string IdentNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Reception> Receptions { get; set; }
    }

    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.IdentNumber).HasMaxLength(12).IsFixedLength().IsRequired();
            builder.Property(x => x.Address).HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Patient)
                .HasForeignKey<Patient>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.IdentNumber);
        }
    }
}
