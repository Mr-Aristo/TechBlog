using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
       // BlogManager bm = new BlogManager(new EFBlogRepository());
        private IBlogService bm;

        public WriterLastBlog(IBlogService bm)
        {
            this.bm = bm;
        }

        public IViewComponentResult Invoke()
        {
            var val = bm.GetBlogListByWriter(2);
            return View(val);
        }
    }
}
