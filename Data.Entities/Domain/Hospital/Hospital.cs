using System.Collections.Generic;
using Data.Entities.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Domain.Hospital
{
    public class Hospital : NameKeyEntityBase<int>
    {
        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }

    public class HospitalConfig : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospitals");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired();
        }
    }
}
