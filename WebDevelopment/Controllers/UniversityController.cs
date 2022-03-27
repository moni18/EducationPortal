using BusinessLogic.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevelopment.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityService _universityService;
        public UniversityController(IUniversityService universityService)
        {
           
            _universityService = universityService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
