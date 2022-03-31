using System;
using Data.Entities.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Domain.Hospital
{
    public class DoctorSchedule : IdKeyEntityBase<int>
    {
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
    }

    public class DoctorScheduleConfig : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.ToTable("DoctorSchedules");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DoctorId);
            builder.Property(x => x.DayOfWeek).IsRequired();
            builder.Property(x => x.Time).IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
