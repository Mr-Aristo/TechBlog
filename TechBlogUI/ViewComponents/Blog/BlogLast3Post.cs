using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
      //  BlogManager bm = new BlogManager(new EFBlogRepository());
        private IBlogService bm;

        public BlogLast3Post(IBlogService bm)
        {
            this.bm = bm;
        }

        public IViewComponentResult Invoke()
        {
            var values = bm.GetLast3Blog();

            return View(values);
        }
    }
}
