using AutoMapper;
using Common.Mappings;
using Data.Entities.Domain.Hospital;

namespace Data.Entities.Models.Hospital
{
    public class PatientViewModel : IMapFrom<Patient>, IMapTo<Patient>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        void IMapFrom<Patient>.Mapping(Profile profile)
        {
            profile.CreateMap<Patient, PatientViewModel>()
                .ForMember(x => x.Name,
                    opts => opts.MapFrom(y => $"{y.User.LastName} {y.User.FirstName}"));
        }
    }
}
