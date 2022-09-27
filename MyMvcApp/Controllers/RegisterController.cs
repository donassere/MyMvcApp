using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using MyMvcApp.Data;
using MyMvcApp.ViewModels;

namespace MyMvcApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUser<ConnectUser> _user;
        public RegisterController(IUser<ConnectUser> user)
        {
            _user = user;
        }
        // GET: Register
        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateUserRequest user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ConnectUser user1 = _user.GetByMail(user.Email);
                    if (user1.Password == user.Password)
                    {

                    }
                    return RedirectToAction(nameof(Register));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
