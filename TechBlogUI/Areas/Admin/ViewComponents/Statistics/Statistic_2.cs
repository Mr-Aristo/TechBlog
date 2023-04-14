using BusinessLayer.Abstracts;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TechBlogUI.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic_2 : ViewComponent
    {
        IAboutService ab;
        Context c = new Context();  


        public Statistic_2(IAboutService ab)
        {
            this.ab = ab;
        }


        public IViewComponentResult Invoke()
        {
            //Descending z den a ya siralama yapar. Numara ise buyukten kucuge dogru siralar.
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogiD).Select(x => x.BlogTitle).Take(1).FirstOrDefault();

            return View();
        }
    }
}
