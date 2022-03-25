using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;


namespace Data.Models.Education
{
    public class StudentViewModel : IMapFrom<Student>, IMapTo<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }

        void IMapFrom<Student>.Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.Name, opts => opts.MapFrom(y => $"{y.LastName} {y.FirstName}"))
                .ForMember(x => x.School, opts => opts.MapFrom(y => $"{y.School.Name}"));
        }
    }
}
