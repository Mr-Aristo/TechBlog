using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstaract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryService cm;

        public CategoryController(ICategoryService cm)
        {
            this.cm = cm;
        }

        public IActionResult Index()
        {

            var values = cm.GetList();
            return View(values);
        }
    }
}
