using Ecommerce.WebUI.Entities;
using Ecommerce.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers;

public class AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager) : Controller
{
    private readonly UserManager<CustomIdentityUser> _userManager = userManager;
    private readonly RoleManager<CustomIdentityRole> _roleManager = roleManager;
    private readonly SignInManager<CustomIdentityUser> _signInManager = signInManager;

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            CustomIdentityUser user = new CustomIdentityUser { UserName = registerViewModel.Username, Email = registerViewModel.Email };
            IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;

            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    CustomIdentityRole role = new CustomIdentityRole
                    {
                        Name = "Admin"
                    };
                    IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError("","We can not add the role");
                        return View(registerViewModel);
                    }
                }
                _userManager.AddToRoleAsync(user, "Admin").Wait();
                return RedirectToAction("Login", "Account");
            }
        }
        return View(registerViewModel);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {

        if(ModelState.IsValid)
        {
            var result = _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,false).Result;
            if (result.Succeeded)
                return RedirectToAction("Index", "Product");
            ModelState.AddModelError("", "Invalid Login");
        }

        return View(model);
    }
}