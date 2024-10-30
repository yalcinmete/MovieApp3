using Microsoft.AspNetCore.Mvc;
using MovieApp3.Web.Models;

namespace MovieApp3.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            return View();
        }
    }
}
