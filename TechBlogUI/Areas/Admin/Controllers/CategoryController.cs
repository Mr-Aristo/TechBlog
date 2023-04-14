using BusinessLayer.Abstracts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using X.PagedList; // Paging(Sayfalama) islemi icin indirdigimiz paket. 
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Nest;

namespace TechBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")] //Programa gelen session larin aredan geldigini bildirdik. 
    public class CategoryController : Controller
    {
        ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        //  [Route("Admin/[Controller]/[Action]/{id?}")]
        public IActionResult Index(int page = 1)
        {
            var values = _category.GetList().ToPagedList(page, 3);//page baslayacagi sayfa degeri. Virgulden sonraki deger de sayfadaki veri sayisi.
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();

            ValidationResult result = cv.Validate(p);



            if (result .IsValid)
            {
                p.CategoryStatus = true;
                _category.tAdd(p);

                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors) // Bu kisimda dogrulama islemi hata firlattiginda hatayi gosterecek donguyu olusturduk.
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = _category.GetById(id);

            _category.tDelete(value);

            return RedirectToAction("Index");
        }
    }
}
