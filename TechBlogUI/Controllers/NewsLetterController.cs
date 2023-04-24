using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private INewsLetterService nm;

        public NewsLetterController(INewsLetterService nm)
        {
            this.nm = nm;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter n)
        {
            n.MailStatus = true;
            nm.AddNewsLetter(n);
            return RedirectToAction("index", "Blog");
        }
    }
}
