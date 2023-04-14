using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TechBlogUI.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic_4 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = c.Admins.Where(x => x.AdminID == 1).Select(X => X.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x=>x.AdminID==1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x=>x.AdminID==1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
