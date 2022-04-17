using AutoMapper;
using Common.Mappings;
using Data.Domain.Education;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Data.Domain;
using Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Data.Models.Education
{
    public class UniversityViewModel : IMapFrom<University>, IMapTo<University>
    {
        public int Id { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string  ManagerId { get; set; }
        public string ManagerName { get; set; }
        public IEnumerable<StudentViewModel> StudentList { get; set; }
        public IEnumerable<ManagerViewModel> ManagerList { get; set; }
        public int StudentsNumber { get; set; }

        void IMapFrom<University>.Mapping(Profile profile)
        {
            profile.CreateMap<University, UniversityViewModel>()
                .ForMember(x => x.ManagerName, opts => opts.MapFrom(y => $"{y.Manager.User.LastName} {y.Manager.User.FirstName}"))
                .ForMember(x => x.StudentsNumber, opts => opts.MapFrom(y => $"{y.Students.Count()}"));

        }
    }
}
