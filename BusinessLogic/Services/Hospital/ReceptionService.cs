using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Domain.Hospital;
using Data.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class ReceptionService : IReceptionService
    {
        private readonly HospitalContext _dbContext;

        public ReceptionService(HospitalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReceptionViewModel>> FetchAsync()
        {
            return await _dbContext.Receptions.Select(x => new ReceptionViewModel
            {
                Id = x.Id,
                CabinetNumber = x.Doctor.CabinetNumber,
                DateTime = x.DateTime,
                DoctorName = $"{x.Doctor.LastName} {x.Doctor.FirstName}",
                PatientName = $"{x.Patient.LastName} {x.Patient.FirstName}"
            }).ToListAsync();
        }

        public async Task<ReceptionViewModel> FetchAsync(int id)
        {
            var reception = await _dbContext.Receptions
                .Include(x => x.Patient)
                .Include(x => x.Doctor).SingleOrDefaultAsync(x => x.Id == id);
            
            //TODO check for null

            return new ReceptionViewModel
            {
                Id = reception.Id,
                CabinetNumber = reception.Doctor.CabinetNumber,
                DateTime = reception.DateTime,
                DoctorName = $"{reception.Doctor.LastName} {reception.Doctor.FirstName}",
                PatientName = $"{reception.Patient.LastName} {reception.Patient.FirstName}"
            };
        }

        public async Task DeleteAsync(int id)
        {
            var reception = await _dbContext.Receptions.SingleOrDefaultAsync(x => x.Id == id);
            
            //TODO check for null

            _dbContext.Receptions.Remove(reception);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReceptionViewModel reception)
        {
            var item = await _dbContext.Receptions.SingleOrDefaultAsync(x => x.Id == reception.Id);

            //TODO check for null

            item.DateTime = reception.DateTime;

            _dbContext.Receptions.Update(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(ReceptionViewModel reception)
        {
            await _dbContext.Receptions.AddAsync(new Reception
            {
                DateTime = reception.DateTime,
                DoctorId = reception.DoctorId,
                PatientId = reception.PatientId
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
