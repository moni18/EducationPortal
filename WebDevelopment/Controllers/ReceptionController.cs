using System.Threading.Tasks;
using BusinessLogic.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebDevelopment.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly IReceptionService _receptionService;

        public ReceptionController(IReceptionService receptionService)
        {
            _receptionService = receptionService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _receptionService.FetchAsync();
            return View("List", items);
        }
    }
}
