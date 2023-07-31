using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechBlogUI.Controllers
{

    public class MessageController : Controller
    {
        private IMessageService mm;
        private IUserService _userService;
        Context c = new Context();

        public MessageController(IMessageService mm, IUserService user)
        {
            this.mm = mm;
            this._userService = user;
        }

        public IActionResult InBox()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);


            return View(values);
        }


        public IActionResult MessageDetails(int id)
        {
            var value = mm.GetById(id);

            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {

            return View();
        }


        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendboxListByWriter(writerID);

            return View(values);
        }


        [HttpPost]
        public IActionResult SendMessage(Message s)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            //List<SelectListItem> recieverUsers = (from x in await _userService.GetUserAsync()

            //                                      select new SelectListItem

            //                                      {

            //                                          Text = x.Email.ToString(),

            //                                          Value = x.Id.ToString()

            //                                      }).ToList();
            //ViewBag.RecieverUser = recieverUsers;


            s.SenderID = writerID;
            s.RecieverID = 1;// bu kisim dinamiklestirilmeli. kullanici mailine gore id cekmeli.!!!!
            s.MessageStatus = true;
            s.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.tAdd(s);
            return RedirectToAction("InBox");


        }

        public IActionResult DeleteMessage(int id)
        {

            var messageId = mm.GetById(id);

            mm.tDelete(messageId);


            return RedirectToAction("InBox", "Message");
        }

        public async Task<IActionResult> RecieverDrowBox()
        {

            List<SelectListItem> recieverUsers = (from x in await _userService.GetUserAsync()

                                                  select new SelectListItem

                                                  {

                                                      Text = x.Email.ToString(),

                                                      Value = x.Id.ToString()

                                                  }).ToList();

            //Burası Yukarıde Çektiğimiz Verileri Front-End Tarafına Taşıyoruz.

            ViewBag.RecieverUser = recieverUsers;

            return View();
        }

    }
}
