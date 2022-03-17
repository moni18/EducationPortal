﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Common.Mappings;
using Data.Domain.Hospital;

namespace Data.Models.Hospital
{
    public class ReceptionViewModel : IMapFrom<Reception>, IMapTo<Reception>
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        //[Range(1, 100, ErrorMessage = "Only positive number allowed")]
        public int CabinetNumber { get; set; }

        [Required(ErrorMessage = "Select doctor")]
        [DisplayName("Doctor")]
        public int DoctorId { get; set; }
        public IEnumerable<DoctorViewModel> DoctorsList { get; set; }

        public string PatientId { get; set; }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }

        void IMapFrom<Reception>.Mapping(Profile profile)
        {
            profile.CreateMap<Reception, ReceptionViewModel>()
                .ForMember(x => x.DoctorName, opts => opts.MapFrom(y => $"{y.Doctor.LastName} {y.Doctor.FirstName}"))
                .ForMember(x => x.PatientName, opts => opts.MapFrom(y => $"{y.Patient.Email}"))
                .ForMember(x => x.CabinetNumber, opts => opts.MapFrom(y => y.Doctor.CabinetNumber));
        }
    }
}
