using BusinessLayer.Abstracts;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace TechBlogUI.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic_1:ViewComponent
    {
        IBlogService bm;
        Context c = new Context(); 

        public Statistic_1(IBlogService bm)
        {
            this.bm = bm;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count;
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            //Key kismi ucretsiz api keyimiz. alttaki linkde apinin linki. xml formatinda cekiyoruz.
            string apiKey = "f4b0d6fdcc622dbbf321b9f6e8df413f";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Ivanovo,3166-2&mode=xml&units=metric&lang=ru&appid=" + apiKey;

            XDocument document =  XDocument.Load(connection);//xml formatini yuklemek icin kullanilan class
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v5 = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            //Descebdabts xml icinde cekmek istedigimiz tag. Element kismi temperature icindeki hangi indexi cekmek istedigimiz.Bir tane var o yuzden 0.
            //attribute ise temperature icinde bir cok attribute var hangisini cekmek istedigimizi belirtiyoruz.

            return View();
        }

    }
}
