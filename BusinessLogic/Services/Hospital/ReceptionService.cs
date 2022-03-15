using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Base;
using Data.Domain.Hospital;
using Data.Models.Hospital;
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
                .Include(x => x.Patient)
                .Include(x => x.Doctor).ToListAsync();

            return Mapper.Map<IEnumerable<ReceptionViewModel>>(items);
        }

        public async Task<ReceptionViewModel> FetchAsync(int id)
        {
            var reception = await _dbContext.Receptions
                .Include(x => x.Patient)
                .Include(x => x.Doctor).SingleOrDefaultAsync(x => x.Id == id);
            
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

            _dbContext.Receptions.Update(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(ReceptionViewModel reception)
        {
            await _dbContext.Receptions.AddAsync(Mapper.Map<Reception>(reception));

            await _dbContext.SaveChangesAsync();
        }
    }
}
