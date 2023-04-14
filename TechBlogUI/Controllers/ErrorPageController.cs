using Microsoft.AspNetCore.Mvc;

namespace TechBlogUI.Controllers
{
    public class ErrorPageController : Controller
    {
        //Startup da alltaki actiona errorun id sinin yolladik. Ayrica bu actiona ait viewimizde var.
        //Amac kullaniciya anlasilamayan bir sayfa yerine hatanin sebebini gosteren ve yonlendiren sayfa implemente etemek.
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
