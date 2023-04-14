using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using TechBlogUI.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.IO;
using System.Linq;

namespace TechBlogUI.Controllers
{
    // [Authorize] bu attribute yi burada kullandigimizda controller icindeki butun islemeler authorize edilmis olur. 
    public class WriterController : Controller
    {
        IWriterService wm;

        public WriterController(IWriterService wm)
        {
            this.wm = wm;
        }

        [Authorize] //Yetklendirme atributu. Login olmadan bu sayfa acilmaz.
        public IActionResult Index()
        {
            //SOLID a aykiri bir yapi. Farkli bir sey dusunmen ve degistrimen gerek. Class bagimliligi var!!
            Context c = new Context();
            var usermail = User.Identity.Name;
            ViewBag.vm = usermail;

            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.vm2 = writerName;

            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
          
            var value = wm.WriterGetById(writerID);
            return View(value);

        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer w)
        {
            WriterValidate wl = new WriterValidate();

            ValidationResult results = wl.Validate(w);

            if (results.IsValid)
            {
                wm.WriterUpdate(w);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();


        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();

            if (p.WriterImage != null)
            {
                var extention = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extention; // Guid Benzersiz isim tanimlamak icin kullanilir. Eklenecek olan resim dosyari icin.
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newimagename);
                var stream = new FileStream(location, FileMode.Create);//Burada alttan gelen veri kaydediliyor.
                p.WriterImage.CopyTo(stream);//Parametereden gelen degieri dosya akisina gonderdik.
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.WriteAdd(w);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
