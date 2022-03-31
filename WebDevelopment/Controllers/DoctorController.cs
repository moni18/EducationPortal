using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities.Models.Hospital;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDevelopment.Controllers
{
    [Authorize(Roles = "Admin, Registrator")]
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public DoctorController(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doctors
                .Include(x => x.Hospital)
                .Include(x => x.User)
                .ToListAsync();

            return View("List",_mapper.Map<IEnumerable<DoctorViewModel>>(doctors));
        }

        public async Task<IActionResult> Details(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
