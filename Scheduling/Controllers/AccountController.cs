using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Models;
using Scheduling.Models.ViewModels;
using Scheduling.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInMangager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(ApplicationDbContext db, 
                                 UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInMangager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInMangager = signInMangager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var result = await _signInMangager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded) return RedirectToAction("Index", "Appointment");

            ModelState.AddModelError("", "Invalid login attemp");
            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Doctor));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Patient));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) 
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            await _userManager.AddToRoleAsync(user, model.RoleName);
            await _signInMangager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logoff()
        {
            await _signInMangager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
