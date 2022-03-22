using System.Collections.Generic;
using AutoMapper;
using Common.Mappings;
using Data.Entities.Domain.Hospital;

namespace Data.Entities.Models.Hospital
{
    public class DoctorViewModel : IMapFrom<Doctor>, IMapTo<Doctor>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public int CabinetNumber { get; set; }
        public string Hospital { get; set; }
        public string Specialization { get; set; }

        void IMapFrom<Doctor>.Mapping(Profile profile)
        {
            profile.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(x => x.Hospital, 
                    opts => opts.MapFrom(y => y.Hospital.Name))
                .ForMember(x => x.Name,
                    opts => opts.MapFrom(y => $"{y.User.LastName} {y.User.FirstName}"));
        }
    }

    public class DoctorRegisterViewModel
    {
        public int CabinetNumber { get; set; }
        public int SelectedHospitalId { get; set; }
        public string Specialization { get; set; }

        public List<HospitalViewModel> Hospitals { get; set; }
    }
}
