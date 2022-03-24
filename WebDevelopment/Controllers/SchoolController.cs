using BusinessLogic.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Data.Models.Education;

namespace WebDevelopment.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;
        private readonly IStudentService _studentService;
        private readonly IManagerService _managerService;
        public SchoolController(ISchoolService schoolService, IStudentService studentService, IManagerService managerService)
        {
            _schoolService = schoolService;
            _studentService = studentService;
            _managerService = managerService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _schoolService.FetchAsync();
            return View("List", items);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create", new SchoolViewModel
            {
                ManagerList = await _managerService.FetchAsync()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(SchoolViewModel school)
        {
            await _schoolService.CreateAsync(school);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _schoolService.FetchAsync(id);
            return View("Details", item);
        }

    }
}
