using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;
using System.Collections.Generic;

namespace Data.Models.Education
{
    public class ManagerViewModel : IMapFrom<Manager>, IMapTo<Manager>
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public ICollection<StudentViewModel> StudentList{ get; set; }

        void IMapFrom<Manager>.Mapping(Profile profile)
        {
            profile.CreateMap<Manager, ManagerViewModel>()
                .ForMember(x => x.Name, opts => opts.MapFrom(y => $"{y.LastName} {y.FirstName}"));
        }
    }
}
