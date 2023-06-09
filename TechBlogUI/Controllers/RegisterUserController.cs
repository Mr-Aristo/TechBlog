﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TechBlogUI.Models;

namespace TechBlogUI.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        UserSignUpViewModel userSignUp = new UserSignUpViewModel();

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]   
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        public async  Task<IActionResult> Index(UserSignUpViewModel p)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname
                    

                };

                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login"); 

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        
                    }
                }
            }

            return View(p);
        }
    }
}
