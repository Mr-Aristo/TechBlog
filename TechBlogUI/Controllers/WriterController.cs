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
using Microsoft.AspNetCore.Identity;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System.Threading.Tasks;
using FluentValidation.Internal;
using DocumentFormat.OpenXml.Office2019.Drawing.Model3D;
using System.Windows.Markup;

namespace TechBlogUI.Controllers
{
    // [Authorize] bu attribute yi burada kullandigimizda controller icindeki butun islemeler authorize edilmis olur. 
    public class WriterController : Controller
    {
        IWriterService wm;
        IUserService _user;


        private readonly UserManager<AppUser> _userManager; //identity sinifi

        public WriterController(IUserService user, IWriterService wm, UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
            this.wm = wm;
            this._user = user;
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
        public async Task<IActionResult> WriterEditProfile()
        {
            UserUpdateViewModel model = new UserUpdateViewModel();


            //FindByNameAsync fonksiyonu onemli bir fonksiyon. 
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            model.email = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            //Bu kisimda modele atama yapmazsak tarayici tarafinda hata aliz. Modelde birsey donmedigi icin 
            //hata aliyoruz.

            return View(model);




        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            WriterValidate wl = new WriterValidate();

            #region  COMMENT
            //identiy ile update islemini model uzerinden gerceklestirdik.
            //Assagidaki yorum satiri icindeki isleme gerek kalmadi.
            //Validation islemi implement edildiginde assagidaki yapi kullanilabilir.

            //  ValidationResult results = wl.Validate(us);
            //if (results.IsValid)
            //{
            //    wm.WriterUpdate(w);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            //    }
            //}
            #endregion


            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.email;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.UserName = model.username;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);
            var result = await _userManager.UpdateAsync(values); // var result olmadanda kullanabiliriz.
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Dashboard");
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
