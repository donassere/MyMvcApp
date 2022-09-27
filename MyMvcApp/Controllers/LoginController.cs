using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }
    }
}
