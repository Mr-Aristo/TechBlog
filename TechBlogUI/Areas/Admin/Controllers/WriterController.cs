using TechBlogUI.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TechBlogUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult WriterList()
        {


            var serialize = JsonConvert.SerializeObject(writers);

            return Json(serialize);
        }

        public IActionResult GetWriterByID(int writerId)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerId);
            var jsonWriters=JsonConvert.SerializeObject(findWriter);

            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterModel w)
        {
            writers.Add(w);
            var jsonWritres= JsonConvert.SerializeObject(w);

            return Json(jsonWritres);
        }
        
        
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.Id == id);
            writers.Remove(writer);

            return Json(writer);
        }

       
        public IActionResult UpdateWriter(WriterModel w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);

            writer.Name= w.Name;

            var jsonWriter= JsonConvert.SerializeObject(w); 

            return Json(jsonWriter);

        }
         
     
        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                Id= 1,
                Name = "Test name1"
            },
            new WriterModel
            {
                Id= 2,
                Name="test 2"
            }

        };

    }
}
