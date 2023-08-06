using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechBlogUI.Models;

namespace TechBlogUI.Controllers
{
    [AllowAnonymous]
    // [AllowAnonymous] // Bu attribute, start up da projeyi authorize ettigimiz kurallardan muaf kilar.
    //Start up da yaptigimiz islem proje genelinde authorize yapmamizi sagladi. Butun sayfalara erisim engellendi.
    //Bu attribute ile login yani authorize kuralini gerceklestirecegimiz sayfaya erisim saglariz.
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true); //false kismi cerezlerde hatirlasinmi true kismi ise kac defa ayanlis girerse sistem kitlenecek.
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();

                }
            }

            return View();

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}


