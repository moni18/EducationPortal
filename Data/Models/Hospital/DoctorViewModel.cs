using AutoMapper;
using Common.Mappings;
using Data.Domain.Hospital;

namespace Data.Models.Hospital
{
    public class DoctorViewModel : IMapFrom<Doctor>, IMapTo<Doctor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CabinetNumber { get; set; }
        public string Hospital { get; set; }

        void IMapFrom<Doctor>.Mapping(Profile profile)
        {
            profile.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(x => x.Hospital, 
                    opts => opts.MapFrom(y => y.Hospital.Name))
                .ForMember(x => x.Name,
                    opts => opts.MapFrom(y => $"{y.LastName} {y.FirstName}"));
        }
    }
}
