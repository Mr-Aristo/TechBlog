
using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TechBlogUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {

        IMessageService mm;
        Context c = new Context();

        public WriterMessageNotification(IMessageService mm)
        {
            this.mm = mm;

        }
        



        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);


            var val = mm.GetInboxListByWriter(writerID);
            return View(val);
        }
    }
}
