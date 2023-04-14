using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Controllers
{
    public class AboutController : Controller
    {
        
       private IAboutService aboutManager;

        public AboutController(IAboutService aboutManager)
        {
            this.aboutManager = aboutManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var list = aboutManager.GetListAbout();
            return View(list);
        }
        [AllowAnonymous]
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
