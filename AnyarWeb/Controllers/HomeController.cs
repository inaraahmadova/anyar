﻿using Microsoft.AspNetCore.Mvc;

namespace AnyarWeb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
