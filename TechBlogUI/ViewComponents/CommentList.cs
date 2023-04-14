using BusinessLayer.Concrete;
using TechBlogUI.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TechBlogUI.ViewComponents
{
    public class CommentList : ViewComponent
    {
        //CommentManager cm = new CommentManager(new EFCommentRepository());
        //List<Comment> comments = new List<Comment>();


        public IViewComponentResult Invoke() // cagrei anlamina gelen fonk
        {
            // Bu kisimda model klasorunu kullandik.

            //comments = cm.GetAllList();


            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                   ID= 1,
                    Username ="testname"
                },
                new UserComment
                {
                    ID=2,
                    Username = "testname2 "
                },
                new UserComment
                {
                    ID = 3,
                    Username =  "testname3"
                }

            };

            return View(commentvalues);
        }
    }
}
