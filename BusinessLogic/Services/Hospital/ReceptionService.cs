using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.Hospital.Base;
using Data.Entities.Domain.Hospital;
using Data.Entities.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Hospital
{
    public class ReceptionService : BaseService, IReceptionService
    {
        private readonly HospitalDbContext _dbContext;

        public ReceptionService(HospitalDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReceptionViewModel>> FetchAsync()
        {
            var items = await _dbContext.Receptions
                .Include(x => x.Patient).ThenInclude(y => y.User)
                .Include(x => x.Doctor).ThenInclude(y => y.User).ToListAsync();

            return Mapper.Map<IEnumerable<ReceptionViewModel>>(items);
        }

        public async Task<IEnumerable<ReceptionViewModel>> FetchAsync(string userId)
        {
            var items = await _dbContext.Receptions.Where(x => x.DoctorId == userId || x.PatientId == userId)
                .Include(x => x.Patient).ThenInclude(y => y.User)
                .Include(x => x.Doctor).ThenInclude(y => y.User).ToListAsync();

            return Mapper.Map<IEnumerable<ReceptionViewModel>>(items);
        }

        public async Task<ReceptionViewModel> FetchAsync(int id)
        {
            var reception = await _dbContext.Receptions
                .Include(x => x.Patient).ThenInclude(y => y.User)
                .Include(x => x.Doctor).ThenInclude(y => y.User).SingleOrDefaultAsync(x => x.Id == id);
            
            //TODO check for null
            
            return Mapper.Map<ReceptionViewModel>(reception);
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
            item.Treatment = reception.Treatment;
            item.Complaint = reception.Complaint;

            _dbContext.Receptions.Update(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(ReceptionViewModel reception)
        {
            await _dbContext.Receptions.AddAsync(Mapper.Map<Reception>(reception));

            await _dbContext.SaveChangesAsync();
        }

        public async Task CloseAsync(int id)
        {
            var item = await _dbContext.Receptions.SingleOrDefaultAsync(x => x.Id == id);

            //TODO check for null

            item.IsCompleted = true;

            _dbContext.Receptions.Update(item);

            await _dbContext.SaveChangesAsync();
        }
    }
}
