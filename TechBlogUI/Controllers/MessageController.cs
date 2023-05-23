using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TechBlogUI.Controllers  
{ 
    //11;41 de kaldik message details calismiyor.!!

    public class MessageController : Controller
    {
        private IMessageService mm;

        public MessageController(IMessageService mm)
        {
            this.mm = mm;
        }

        public IActionResult InBox()
        {
            int id = 1;
            var val = mm.GetInboxListByWriter(id);

            return View(val);
        }

      
        public IActionResult MessageDetails(int id)
        {
            var value = mm.GetById(id);
            
            return View(value);
        }
    }
}
