﻿using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
