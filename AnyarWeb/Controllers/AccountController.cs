using Microsoft.AspNetCore.Mvc;
using AnyarWeb.Models;

namespace AnyarWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
