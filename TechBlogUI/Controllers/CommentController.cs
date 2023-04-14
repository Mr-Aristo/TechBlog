using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace TechBlogUI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
      
        readonly ICommentService cm;

        public CommentController(ICommentService cm)
        {
            this.cm = cm;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            
            return PartialView();   
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment cmd)
        {
            Context c = new Context();
            cmd.CommentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            cmd.CommentStatus = true;
            cmd.BlogID =  c.Blogs.Where(c => c.BlogiD == cmd.BlogID).Select(x => x.BlogiD).FirstOrDefault(); 
            cm.CommentAdd(cmd);

            return RedirectToAction("BlogReadAll", "Blog", new { id = cmd.BlogID });
        }


        public PartialViewResult CommentListByBlog(int id)
        {
            ViewBag.i = id;
            var val=  cm.GetList(id);
            return PartialView(val);
        }



    }
}
