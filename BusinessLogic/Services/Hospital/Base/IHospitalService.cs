﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities.Models.Hospital;

namespace BusinessLogic.Services.Hospital.Base
{
    public interface IHospitalService
    {
        Task<IEnumerable<HospitalViewModel>> FetchAsync();
    }
}
