using Data.Domain.Education;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


//namespace DataAccessLayer.Configs.EducationConfigs
//{
//    public class PupilConfig : IEntityTypeConfiguration<Pupil>
//    {
//        public void Configure(EntityTypeBuilder<Pupil> builder)
//        {
//            builder.ToTable("Pupils");
//            builder.HasKey(x => x.UserId);
//            builder.Property(x => x.SchoolId);

//            builder.HasOne(x => x.User)
//                .WithOne(x => x.Pupil)
//                .HasForeignKey<Pupil>(x => x.UserId)
//                .OnDelete(DeleteBehavior.Cascade);

//            builder.HasOne(x => x.School)
//                .WithMany(x => x.Pupils)
//                .HasForeignKey(x => x.SchoolId)
//                .OnDelete(DeleteBehavior.Cascade);


//        }
//    }
//}