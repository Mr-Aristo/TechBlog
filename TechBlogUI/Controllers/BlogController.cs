
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using DataAccessLayer.Concrete;
using BusinessLayer.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace TechBlogUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _webHost;

        readonly IBlogService bm; //Dependency injection ile yaptik
                                  // BlogManager bm = new BlogManager(new EFBlogRepository());
        readonly ICategoryService cm;
        readonly IWriterService wm;
        BlogValidator bw = new BlogValidator();

        Context c = new Context();

        public BlogController(IBlogService bm, IWebHostEnvironment webHost)
        {
            this.bm = bm;
            this._webHost = webHost;
        }

       
        [AllowAnonymous]
        public IActionResult Index()
        {
            Writer writer = new Writer();
            ViewBag.v = writer.WriterName;
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {


            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogListByWriter()
        {

            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithListByWriterBM(writerID);

            return View(values);
        }


        #region Blog Insert 
        [HttpGet]
        public IActionResult BLogAdd()
        {


            List<SelectListItem> categoryvalues = (from x in cm.GetList() //Dropdown da listleeme icin hazirladigimiz yapi
                                                   select new SelectListItem //drowpdownun iki parameteresi vardir Text(icerik) and Values (id)
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString() //int to string hatasi aldik. Sonunada ToList demessek hata aliyoruz.
                                                   }).ToList();

            ViewBag.cv = categoryvalues; // Viewbag burdaki aldigimiz veriyi viewe tasimamizi saglar. Yine ayni sekilde view icinde Viewbag.cv diyerek kullanacagiz.
            return View();
        }

        [HttpPost]
        public IActionResult BLogAdd(Blog b)
        {
            Context c = new Context();

            //Blog eklemede identity kullandigimiz icin foreing key hatasi aliyorduk. Asagidaki kod ile idyi basarili bir sekilde cektik.
            //Islem writer tablosundaki mail ve aspnetuser tablosundaki mail eslesmesiyle yapiliyor.
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ValidationResult results = bw.Validate(b); //using FluentValidation.Results; ile kullanilmali yoksa hata aliyoruz.

            //**************************/
            // Bu Yapiyi HttpPost icinde kulannmazs isek veri girmeden blog create yapmaya calistigimizda categorileri
            // cekemedigi icin hata veriyor ve validation calismiyor.
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            //**************************/
            var val = b.WriterID;




            if (results.IsValid)
            {
                b.BlogStatus = true;
                b.CreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
                b.WriterID = writerID;
                bm.BlogAdd(b);

                return RedirectToAction("BlogListByWriter", "Blog"); // Burada blog icindeki index aksiyona git dedik. Blog controller , index controller icindeki action fonksiyonu.
            }
            else
            {
                foreach (var item in results.Errors) // Bu kisimda dogrulama islemi hata firlattiginda hatayi gosterecek donguyu olusturduk.
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        //private string UploadFile(Blog bl)
        //{
        //    string fileName = null;
        //    if (bl.BlogImage != null)
        //    {
        //        string uploadDir = Path.Combine(_webHost.WebRootPath, "images");
        //        fileName = Guid.NewGuid().ToString() + "-" + bl.BlogImage.FileName;
        //        string filePath = Path.Combine(uploadDir, fileName);
        //        using (var fileStream= new FileStream(filePath, FileMode.Create))
        //        {
        //            bl.BlogImage.CopyTo(fileStream);
        //        }
        //    }
        //}


        #endregion



        #region Blog Delete

        public IActionResult DeleteBlog(int id)
        {

            var blogvalue = bm.TGetById(id);

            bm.BlogDelete(blogvalue);

            return RedirectToAction("BlogListByWriter", "Blog");
        }
        #endregion


        #region Blog Edit

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList() //Dopdown da listleeme icin hazirladigimiz yapi
                                                   select new SelectListItem //drowpdownun iki parameteresi vardir Text(icerik) and Values (id)
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString() //int to string hatasi aldik. Sonunada ToList demessek hata aliyoruz.
                                                   }).ToList();

            ViewBag.cv = categoryvalues;

            return View(value);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            //bukisimda arayuzde etdit etmedigimiz degerleri atadaik.
            //Ornek olarak kullanici arayuzunde writerId girmiyor.Veritabanina null atamamasi icin bu sekilde yaptik.
            var blogToUpdate = bm.TGetById(p.BlogiD);
            p.WriterID = blogToUpdate.WriterID;
            p.CreateDate = blogToUpdate.CreateDate;
            p.BlogStatus = blogToUpdate.BlogStatus;


            bm.BlogUpdate(p);

            return RedirectToAction("BlogListByWriter");

        }


        #endregion


       
    }
}
