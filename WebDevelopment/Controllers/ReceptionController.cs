using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Hospital;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDevelopment.Controllers
{
    [Authorize]
    public class ReceptionController : Controller
    {
        private readonly IReceptionService _receptionService;
        private readonly IDoctorService _doctorService;

        public ReceptionController(IReceptionService receptionService, IDoctorService doctorService)
        {
            _receptionService = receptionService;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _receptionService.FetchAsync();
            return View("List", items);
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Create()
        {
            return View("Create", new ReceptionViewModel
            {
                DoctorsList = await _doctorService.FetchAsync()
            });
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Create(ReceptionViewModel reception)
        {
            reception.PatientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _receptionService.CreateAsync(reception);

            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _receptionService.FetchAsync(id);
            return View("Details", item);
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Delete(int id)
        {
            await _receptionService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _receptionService.FetchAsync(id);
            return View("Edit", item);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Edit(ReceptionViewModel reception)
        {
            await _receptionService.UpdateAsync(reception);
            return RedirectToAction("Index");
        }
    }
}
