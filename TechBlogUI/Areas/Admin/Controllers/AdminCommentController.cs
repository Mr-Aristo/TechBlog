using BusinessLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        ICommentService cs;

        public AdminCommentController(ICommentService cs)
        {
            this.cs = cs;
        }

        public IActionResult Index()
        {
            var values = cs.GetListWithBlog();//Blogla birlikte getrimek icin IcommentDal da yeni fonk tanimlandi.
            return View(values);
        }

        
        public IActionResult DeleteComment(int id)
        {
            var value = cs.GetById(id);
            cs.CommentDelete(value);
            

            return RedirectToAction("Index", "AdminComment");


        }
    }
}
