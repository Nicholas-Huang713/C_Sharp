using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string name, string location, string language, string comment)
        {
            return RedirectToAction("Show", new {name = name, location = location, language = language, comment = comment});
        }

        [HttpGet("show")]
        public ViewResult Show(string name, string location, string language, string comment)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;

            // Home someUser = new Home()
            // {
            //     FirstName = "Nick",
            //     LastName = "Huang"
            // };


            return View("Show");
        }
    }
}
