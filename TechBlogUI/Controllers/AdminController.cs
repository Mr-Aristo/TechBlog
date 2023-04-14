using Microsoft.AspNetCore.Mvc;
using Nest;

namespace TechBlogUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }


    }
}
