using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;
using System.Collections.Generic;

namespace Data.Models.Education
{
    public class ManagerViewModel : IMapFrom<Manager>, IMapTo<Manager>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public ICollection<StudentViewModel> StudentList{ get; set; }

        void IMapFrom<Manager>.Mapping(Profile profile)
        {
            profile.CreateMap<Manager, ManagerViewModel>()
                .ForMember(x => x.Name, opts => opts.MapFrom(y => $"{y.User.LastName} {y.User.FirstName}"));
        }
    }

}
