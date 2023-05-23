using BusinessLayer.Abstracts;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TechBlogUI.ViewComponents.Writer
{
    public class WriterNameNavbar:ViewComponent
    {
        IWriterService _writerService;
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.WriterName = username;


            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault(); //Mail e gore islem yapacagimiz icin boyle yaptik 

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = _writerService.GetWriterById(writerID);

            return View();
        }
            
    }
}
