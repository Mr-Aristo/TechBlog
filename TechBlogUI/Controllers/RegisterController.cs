using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Controllers
{
    public class RegisterController : Controller
    {
        private IWriterService _manager;

        public RegisterController(IWriterService manager)
        {
            _manager = manager;
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //Burada bir parametree girimeliyiz, cunku funk isimleri ayni ve hata aliriz. 
        public IActionResult Index(Writer w)
        {
            WriterValidate wv = new WriterValidate();
            ValidationResult results = wv.Validate(w);
            

            if (results.IsValid)
            {
                w.WriterStatus = true;
                w.WriterAbout = "Test";
                _manager.WriteAdd(w);
                return RedirectToAction("Index", "Blog"); // Burada blog icindeki index aksiyona git dedik. Blog controller , index controller icindeki action fonksiyonu.
            }
            else
            {
                foreach(var item in results.Errors) // Bu kisimda dogrulama islemi hata firlattiginda hatayi gosterecek donguyu olusturduk.
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
