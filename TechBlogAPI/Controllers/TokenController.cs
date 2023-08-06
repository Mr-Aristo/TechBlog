using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlogAPI.DAL;

namespace TechBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult LoginWithToken()
        {
            return Created("",new BuildWebToken().CreateToken()); 
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TestPage()
        {
            return Ok("Successfuly reached to page! Token Worked!");

        }
    }
}
