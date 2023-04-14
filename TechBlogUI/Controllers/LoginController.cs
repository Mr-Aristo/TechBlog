using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechBlogUI.Models;

namespace TechBlogUI.Controllers
{
    [AllowAnonymous]
    // [AllowAnonymous] // Bu attribute, start up da projeyi authorize ettigimiz kurallardan muaf kilar.
    //Start up da yaptigimiz islem proje genelinde authorize yapmamizi sagladi. Butun sayfalara erisim engellendi.
    //Bu attribute ile login yani authorize kuralini gerceklestirecegimiz sayfaya erisim saglariz.
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true); //false kismi cerezlerde hatirlasinmi true kismi ise kac defa ayanlis girerse sistem kitlenecek.
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();

                }
            }

            return View();

        }


        //[HttpPost]
        //public async Task<IActionResult> Index(Writer p)
        //{
        //    //FirstOrDefault, linq de tek deger getirmek yada sorgulama, islem yapmak icin kullanilir.

        //    Context c = new Context();

        //    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
        //    x.WriterPassword == p.WriterPassword);

        //    if (datavalue != null)
        //    {
        //        //Talep olusturuyoruz. Claims kullanici hakkinda bilgileri tutan yapi.
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.WriterMail)

        //            //new Claim(ClaimTypes. Email, p.WriterMail),
        //            //new Claim(ClaimTypes. Name, p.WriterID.ToString())
        //        };

        //        //Alttaki fonksiyounda claims den sonra her hangi bir string girilmelidir.
        //        //Eğer string parametre girilmezse  kimlik doğrulama olmadan bir oturum başlatılıyor.
        //        //Bu sebepten hala sistemde hiçbir sayfayı göremez halde oluyoruz. 
        //        var useridentity = new ClaimsIdentity(claims, "a");

        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

        //        await HttpContext.SignInAsync(principal);

        //        return RedirectToAction("Index", "Dashboard");


        //    }
        //    else
        //    {
        //        return View();
        //    }


    }
}


