﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogic.Services.Education;
using Data.Domain.Education;
using Data.Domain.Identity;
using Data.Enums;
using Data.Models.Education;
using Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebDevelopment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UniversityService _universityService;
        
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager,
            UniversityService universityService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _universityService = universityService;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel
            {
                Roles = _roleManager.Roles.Where(x => x.IsRegister).ToList(),

                Student = new StudentRegisterViewModel
                {
                    Universities = (await _universityService.FetchAsync()).ToList(),
                    //Schools = (await _universityService.FetchAsync()).ToList()
                }
             

            });
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Manager = model.RoleName == RolesEnum.Manager.ToString() ? new Manager() : null,
                    Student = model.RoleName == RolesEnum.Student.ToString() ? new Student
                    {
                        UniversityId = model.Student.UniversityId
                        
                    } : null    
                    //    new Student()
                    //{
                    //    SchoolId = model.Student.SchoolId
                    //}
                    
                };
                

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

    }
}
