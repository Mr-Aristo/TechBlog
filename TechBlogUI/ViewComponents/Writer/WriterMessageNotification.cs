
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EFMessageRepository());

        public IViewComponentResult Invoke()
        {
            int id = 2;
            var val = mm.GetInboxListByWriter(id);
            return View(val);
        }
    }
}
