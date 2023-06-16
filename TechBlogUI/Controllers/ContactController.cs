using BusinessLayer.Abstracts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TechBlogUI.Controllers
{
    public class ContactController : Controller
    {
        private IContactService cn;

        public ContactController(IContactService cn)
        {
            this.cn = cn;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContactDate = System.DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContactStatus = true;
            cn.Add(p);

            return RedirectToAction("Index", "Blog");
        }
    }
}
