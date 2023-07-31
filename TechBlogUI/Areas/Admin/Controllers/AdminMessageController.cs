using BusinessLayer.Abstracts;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace TechBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IMessageService _message;

        Context c = new Context();

        

        public AdminMessageController(IMessageService message)
        {
            _message = message;
        }


        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x=>x.UserName == username).Select(x=>x.Email).FirstOrDefault();
            var UserId = c.Writers.Where(x=>x.WriterMail==usermail).Select(x=>x.WriterID).FirstOrDefault();
            var values = _message.GetInboxListByWriter(UserId);
        
            return View(values);
        }

        

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = _message.GetSendboxListByWriter(writerID);

            return View(values);
        }


        [HttpGet]
        public IActionResult ComposeMessage()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult ComposeMessage(Message ms)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
                        
            ms.SenderID = writerID;
            ms.RecieverID = 1; // dinamik sekilde reciever id alinmasi gerek.
            ms.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ms.MessageStatus = true;
            _message.tAdd(ms);

            return RedirectToAction("SendBox");
        }



    }
}
