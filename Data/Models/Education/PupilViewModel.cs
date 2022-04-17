using System.Collections.Generic;
using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;


//namespace Data.Models.Education
//{
//    public class PupilViewModel : IMapFrom<Pupil>, IMapTo<Pupil>
//    {
//        public string UserId { get; set; }
//        public string Name { get; set; }
//        public string School { get; set; }
//        void IMapFrom<Pupil>.Mapping(Profile profile)
//        {
//            profile.CreateMap<Pupil, PupilViewModel>()
//                .ForMember(x => x.Name, opts => opts.MapFrom(y => $"{y.User.LastName} {y.User.FirstName}"))
//                .ForMember(x => x.School, opts => opts.MapFrom(y => $"{y.School.Name}"));
//        }
//    }

//    public class PupilRegisterViewModel
//    {
//        public int SchoolId { get; set; }
//        public string School { get; set; }
//        public List<UniversityViewModel> Schools { get; set; }
//    }
//}