using Data.Domain.Education;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccessLayer.Configs.EducationConfigs
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UniversityId);
            builder.Property(x => x.SchoolId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Student)
                .HasForeignKey<Student>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(x => x.University)
            //    .WithMany(x => x.Students)
            //    .HasForeignKey(x => x.UniversityId)
            //    .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
