using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UVEMS.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserInfoService _service;

        public UserController()
        {
            _service = new UserInfoService();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserInfo user)
        {
            _service.AddUser(user);
            return RedirectToAction("Register");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string EmailId, string Password)
        {
            var user = _service.Login(EmailId, Password);

            if (user != null)
            {
                return Content("Login Successful");
            }
            else
            {
                return Content("Invalid Credentials");
            }
        }
    }
}
