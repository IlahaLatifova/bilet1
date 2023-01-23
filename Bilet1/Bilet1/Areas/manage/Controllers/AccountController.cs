using Bilet1.Models;
using Bilet1.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilet1.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user = new AppUser()
        //    {
        //        FullName = "Ilaha Latifova",
        //        UserName = "Admin"
        //    };
        //   IdentityResult? result = await _userManager.CreateAsync(user,"admiN1902@");
        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return Ok(result);
        //}
        //public async  Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role = new IdentityRole("Admin");
        //    await _roleManager.CreateAsync(role);
        //    return Ok("yarandi");
        //}
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUser )
        {
            if (!ModelState.IsValid)
            {
                return View(loginUser);
            }
            AppUser appuser = await _userManager.FindByNameAsync(loginUser.UserName);
            if(appuser is null)
            {
                ModelState.AddModelError("", "User name or Password is not correct!!!");
            }
            Microsoft.AspNetCore.Identity.SignInResult? result = await _signInManager.PasswordSignInAsync(appuser, loginUser.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View(loginUser);
            }
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
