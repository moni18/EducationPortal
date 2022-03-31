using System.Threading.Tasks;
using AutoMapper;
using Data.Entities.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDevelopment.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public PatientController(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientViewModel))]
        public async Task<IActionResult> Get(string iin)
        {
            var patient = await _context.Patients
                .Include(x => x.User)
                .Include(x => x.Receptions)
                .SingleOrDefaultAsync(x => x.IdentNumber == iin);

            return Ok(_mapper.Map<PatientViewModel>(patient));
        }
    }
}
