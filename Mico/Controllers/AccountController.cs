using Mico.Models;
using Mico.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mico.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (registerVM == null)
            {
                ModelState.AddModelError("","Bos qoyma");
            }
            AppUser appUser = new()
            {
                Name = registerVM.Name,
                Surname=registerVM.Surname,
                Email=registerVM.EmailAdress,  
            };
            
            var result=await _userManager.CreateAsync(appUser,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach(var results in result.Errors)
                {
                    ModelState.AddModelError("", results.Description);
                }    
                return View();
            }


           return RedirectToAction("Login", "Account");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           
            AppUser user=await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user==null)
            {
                ModelState.AddModelError("", "Sevh Melumat");
                return View(loginVM);
            }
            var result=await _signInManager.PasswordSignInAsync(user,loginVM.Password,true,false);

            return RedirectToAction("index", "home");
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
