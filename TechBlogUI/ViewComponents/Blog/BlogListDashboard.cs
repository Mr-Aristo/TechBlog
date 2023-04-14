using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        //BlogManager bm = new BlogManager(new EFBlogRepository());
        private IBlogService bm;

        public BlogListDashboard(IBlogService bm)
        {
            this.bm = bm;
        }

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory();
            
            return View(values);
        }

         
    }
}
