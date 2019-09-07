using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FishApp.Models;

namespace FishApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("registration")]
        public IActionResult Register()
        {
            return View("Registration");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }
    }
}
