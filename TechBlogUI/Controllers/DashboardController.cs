﻿using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TechBlogUI.Controllers
{
    public class DashboardController : Controller
    {
        private IBlogService bm;

        public DashboardController(IBlogService bm)
        {
            this.bm = bm;
        }

        //BlogManager bm = new BlogManager(new EFBlogRepository());

        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.v3 = c.Categories.Count();

            return View();
        }
    }
}
