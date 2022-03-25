using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;
using System.Collections.Generic;
using System.Linq;


namespace Data.Models.Education
{
    public class SchoolViewModel : IMapFrom<School>, IMapTo<School>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public IEnumerable<StudentViewModel> StudentList { get; set; }
        public IEnumerable<ManagerViewModel> ManagerList { get; set; }
        public int StudentsNumber { get; set; }

        void IMapFrom<School>.Mapping(Profile profile)
        {
            profile.CreateMap<School, SchoolViewModel>()
                .ForMember(x => x.ManagerName, opts => opts.MapFrom(y => $"{y.Manager.LastName} {y.Manager.FirstName}"))
                .ForMember(x => x.StudentsNumber, opts => opts.MapFrom(y => $"{y.Students.Count()}"));
        }
    }
}
