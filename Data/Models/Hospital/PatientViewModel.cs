using AutoMapper;
using Common.Mappings;
using Data.Domain.Hospital;

namespace Data.Models.Hospital
{
    public class PatientViewModel : IMapFrom<Patient>, IMapTo<Patient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public string Complaint { get; set; }

        void IMapFrom<Patient>.Mapping(Profile profile)
        {
            profile.CreateMap<Patient, PatientViewModel>()
                .ForMember(x => x.Name,
                    opts => opts.MapFrom(y => $"{y.LastName} {y.FirstName}"));
        }
    }
}
