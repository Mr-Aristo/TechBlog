

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Comments
{
    public class CommentListByBlog:ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public  IViewComponentResult Invoke(int id )
        {
            var val = cm.GetList(id);
            if(val == null)
            {
                return View("Enter first comment");
            }

            return View(val);
        }

    }
}
