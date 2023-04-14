using TechBlogUI.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TechBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }    
        
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass
            {
                categoryname ="Yazilim",
                categorycount= 13,
            });
            list.Add(new CategoryClass
            {
                categoryname ="Spor",
                categorycount= 123,
            });
            return Json(new { jsonlist = list }); // jsonlist json datamizin adi.
            //Json tipinde donduruyoruz. View tarafinda ajax ve js kullandik.
        }

        //public List<CategoryClass> Chart()
        //{
        //    List<CategoryClass> cc = new List<CategoryClass>();

        //    using (var c = new Context())
        //    {
        //        cc= c.Categories.Select

        //    }

        //}
    }
}
