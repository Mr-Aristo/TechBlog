using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Category
{
    public class CategoryList : ViewComponent 
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        
        public IViewComponentResult Invoke()
        {
            var val = cm.GetList();

            return View(val);
        }

    }
}
