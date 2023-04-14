using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;

namespace TechBlogUI.Controllers
{
    public class NotificationController : Controller
    {
        private INotificationService nm;

        public NotificationController(INotificationService nm)
        {
            this.nm = nm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotifications()
        {
            var val = nm.GetList();

     

            return View(val);   
        }
    }
}
