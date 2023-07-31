using BusinessLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        IBlogService _blogService;

        public AdminBlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var value = _blogService.GetBlogListWithCategory();

            return View(value);
        }
    }
}
