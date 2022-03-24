﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.Hospital.Base;
using Data.Entities.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class DoctorService : BaseService, IDoctorService
    {
        private readonly HospitalDbContext _dbContext;

        public DoctorService(HospitalDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DoctorViewModel>> FetchAsync()
        {
            return Mapper.Map<IEnumerable<DoctorViewModel>>(await _dbContext.Doctors.Include(x => x.User).ToListAsync());
        }
    }
}