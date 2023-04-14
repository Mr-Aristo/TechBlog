using ClosedXML.Excel;//Excel islemleri icin kullanilan kutuphane.
using TechBlogUI.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2016.Presentation.Command;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TechBlogUI.Areas.Admin.ControllersW
{
    [Area("Admin")]
    public class BlogController : Controller
    {

        #region Excel Static List
        public IActionResult ExportStaticBlogList() //Bloglari excele export etme islemi. Model Ile manuel olarak veri giridik.
        {
            using (var workbook = new XLWorkbook()) // workbook excelin kendisi sheet ise sayfa
            {
                var worksheet = workbook.Worksheets.Add("Blog List"); // Sayfa ismi belirledik
                worksheet.Cell(1, 1).Value = "Blog ID"; // birinci sayir birinci sutun
                worksheet.Cell(1, 2).Value = "Blog Name"; //Ikinci satir ikinci sutun

                int BlogRowCount = 2; // 2 nin sebebi ilk iki satira baslik gelecefgi icin -2 den baslatiyoruz.

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Wrok1.xlsx"); // ilik girilen link excelin formatlarinin oldugu
                    //bir websitesi. ikinci ise dosyanin adi.
                }
            }

        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel {ID=1,BlogName="Blog test 1 "},
                new BlogModel {ID=2,BlogName="Blog test 2 "},
                new BlogModel {ID=3,BlogName="Blog test 3 "}
            };

            return bm;

        }

        #endregion

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList() //Burada ise dynamic yani db den veri cektik.
        {
            using (var workbook = new XLWorkbook()) // workbook excelin kendisi sheet ise sayfa
            {
                var worksheet = workbook.Worksheets.Add("Blog List"); // Sayfa ismi belirledik
                worksheet.Cell(1, 1).Value = "Blog ID"; // birinci sayir birinci sutun
                worksheet.Cell(1, 2).Value = "Blog Name"; //Ikinci satir ikinci sutun

                int BlogRowCount = 2; // 2 nin sebebi ilk iki satira baslik gelecefgi icin 2 den baslatiyoruz.

                foreach (var item in GetBlogListDynamic())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Wrok1.xlsx"); // ilik girilen link excelin formatlarinin oldugu
                    //bir websitesi. ikinci ise dosyanin adi.
                }
            }
        }

        public List<BlogModelDynamic> GetBlogListDynamic()
        {
            List<BlogModelDynamic> bm = new List<BlogModelDynamic>();

            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModelDynamic
                {
                    ID = x.BlogiD,
                    BlogName = x.BlogTitle

                }).ToList();
            }


            return bm;
        }

    }
}
