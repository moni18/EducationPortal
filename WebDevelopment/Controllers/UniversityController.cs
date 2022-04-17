using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogic.Services.Education;
using Data.Domain.Education;
using Data.Models.Education;
using Microsoft.AspNetCore.Authorization;
using Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDevelopment.Controllers
{
    //[Authorize]
    public class UniversityController : Controller
    {
        private readonly UniversityService _universityService;
        private readonly StudentService _studentService;
        private readonly ManagerService _managerService;
       
        public UniversityController(UniversityService universityService, StudentService studentService, ManagerService managerService)
        {
            _universityService = universityService;
            _studentService = studentService;
            _managerService = managerService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _universityService.FetchAsync();
            return View("List", items);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create", new UniversityViewModel
            {
                ManagerList = await _managerService.FetchAsync()

            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(UniversityViewModel university)
        {
            await _universityService.CreateAsync(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _universityService.FetchAsync(id);
            return View("Details", item);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _universityService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _universityService.FetchAsync(id);
            return View("Edit", item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UniversityViewModel school)
        {
            await _universityService.UpdateAsync(school);
            return RedirectToAction("Index");
        }
    }
}
