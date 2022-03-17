using BusinessLogic.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebDevelopment.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _schoolService.FetchAsync();
            return View("List", items);
        }
    }
}
