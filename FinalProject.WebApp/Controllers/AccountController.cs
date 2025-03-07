using FinalProject.Entities.DTOs;
using FinalProject.Services.Contracts;
using FinalProject.WebApp.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager, IServiceManager serviceManager)
        {
            _signInManager = signInManager;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _serviceManager.UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                { return RedirectToAction("Index", "Home"); }
                else 
                {
                    ModelState.AddModelError("","Giriş işlemi başarışız.");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout() 
        { 
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
