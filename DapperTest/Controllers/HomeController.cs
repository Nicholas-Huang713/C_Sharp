using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DapperTest.Models;
using DbConnection;
using DapperApp.Factory; 

namespace DapperTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Users = userFactory.FindAll();
            return View();
        }

    
    }
}
