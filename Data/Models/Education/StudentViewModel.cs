using System.Collections.Generic;
using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;


namespace Data.Models.Education
{
    public class StudentViewModel : IMapFrom<Student>, IMapTo<Student>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        void IMapFrom<Student>.Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.Name, opts => opts.MapFrom(y => $"{y.User.LastName} {y.User.FirstName}"))
                .ForMember(x => x.University, opts => opts.MapFrom(y => $"{y.University.Name}"));

        }
    }

    public class StudentRegisterViewModel
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public List<UniversityViewModel> Universities { get; set; }
      
    }
}
