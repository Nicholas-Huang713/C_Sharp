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
        public IActionResult Submit(Survey newSurvey)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Show", newSurvey);
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet("show")]
        public ViewResult Show(Survey newSurvey)
        {
            ViewBag.Name = newSurvey.Name;
            ViewBag.Location = newSurvey.Location;
            ViewBag.Language = newSurvey.Language;
            ViewBag.Comment = newSurvey.Comment;
            return View("Show");
        }
    }
}
