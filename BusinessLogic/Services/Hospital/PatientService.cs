using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class PatientService : IPatientService
    {
        private readonly HospitalContext _dbContext;

        public PatientService(HospitalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PatientViewModel>> FetchAsync()
        {
            return await _dbContext.Patients.Select(x => new PatientViewModel
            {
                Id = x.Id,
                Complaint = x.Complaint,
                Diagnosis = x.Diagnosis,
                Name = $"{x.LastName} {x.FirstName}"
            }).ToListAsync();
        }
    }
}
