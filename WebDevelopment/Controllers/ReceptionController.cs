using System.Threading.Tasks;
using BusinessLogic.Base;
using Data.Models.Hospital;
using Microsoft.AspNetCore.Mvc;

namespace WebDevelopment.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly IReceptionService _receptionService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public ReceptionController(IReceptionService receptionService, IDoctorService doctorService, IPatientService patientService)
        {
            _receptionService = receptionService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _receptionService.FetchAsync();
            return View("List", items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create", new ReceptionViewModel
            {
                DoctorsList = await _doctorService.FetchAsync(),
                PatientsList = await _patientService.FetchAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceptionViewModel reception)
        {
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
        public async Task<IActionResult> Delete(int id)
        {
            await _receptionService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _receptionService.FetchAsync(id);
            return View("Edit", item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReceptionViewModel reception)
        {
            await _receptionService.UpdateAsync(reception);
            return RedirectToAction("Index");
        }
    }
}
