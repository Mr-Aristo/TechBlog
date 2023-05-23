using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TechBlogUI.ViewComponents.Writer
{
    public class WritertAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        Context c = new Context();


        public IViewComponentResult Invoke()
        {
            //Sisteme Authentice olan yazarin bilgilerini getirdik.
            //Bunun icin Writer  tablosindaki mail ile Aspnetusers icindeki mail kismi ayni olmali.
            var username = User.Identity.Name;
            ViewBag.v = username;
            var usermail = c.Users.Where(x=>x.UserName==username).Select(y=> y.Email).FirstOrDefault(); //Mail e gore islem yapacagimiz icin boyle yaptik 
            
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerID);

            return View(values);
        }
        
    }
}


