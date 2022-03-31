using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogic.Services.Hospital;
using Data.Entities.Models;
using Data.Entities.Models.Hospital;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDevelopment.Controllers
{
    [Authorize]
    public class ReceptionController : Controller
    {
        private readonly ReceptionService _receptionService;
        private readonly DoctorService _doctorService;

        public ReceptionController(ReceptionService receptionService, DoctorService doctorService)
        {
            _receptionService = receptionService;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var items = await _receptionService.FetchAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View("List", PaginatedList<ReceptionViewModel>.Create(items.ToList(), page ?? 1, 5));
        }

        public async Task<IActionResult> List(string search, string sort, string filter, int? page)
        {
            ViewData["CurrentSort"] = sort;
            ViewData["DoctorNameSortParam"] = string.IsNullOrEmpty(sort) ? "doctor_name" : "doctor_name_desc";
            ViewData["PatientNameSortParam"] = string.IsNullOrEmpty(sort) ? "patient_name_desc" : "patient_name";
            ViewData["DateSortParam"] = sort == "date" ? "date_desc" : "date";

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = filter;
            }

            ViewData["CurrentFilter"] = search;

            var items = await _receptionService.FetchAsync();
            items = sort switch
            {
                "doctor_name_desc" => items.OrderByDescending(x => x.DoctorName),
                "patient_name_desc" => items.OrderByDescending(x => x.PatientName),
                "doctor_name" => items.OrderBy(x => x.DoctorName),
                "patient_name" => items.OrderBy(x => x.PatientName),
                "date_desc" => items.OrderByDescending(x => x.DateTime),
                _ => items.OrderBy(x => x.DateTime),
            };
            if (!string.IsNullOrEmpty(search))
                items = items.Where(x => x.PatientName.ToLower().Contains(search.ToLower()));
            
            return View("List", PaginatedList<ReceptionViewModel>.Create(items.ToList(), page ?? 1, 5));
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
        [Authorize(Roles = "Patient, Doctor")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _receptionService.FetchAsync(id);
            return View("Edit", item);
        }

        [HttpPost]
        [Authorize(Roles = "Patient, Doctor")]
        public async Task<IActionResult> Edit(ReceptionViewModel reception)
        {
            await _receptionService.UpdateAsync(reception);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Close(int id)
        {
            await _receptionService.CloseAsync(id);
            return RedirectToAction("Index");
        }
    }
}
