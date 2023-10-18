using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepos;
using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private readonly INotificationService nm;

        public WriterNotification(INotificationService nm)
        {
            this.nm = nm;
        }

        public IViewComponentResult Invoke()
        {
            var values = nm.GetList();

            return View(values);
        }
    }
}
