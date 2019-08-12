using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            string message = "This is a message This is a message This is a message This is a message This is a message This is a message This is a message";

            return View("Index", message);
        }

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[]
            {
                1,2,3,4,5,6,7
            };
            return View("Numbers", numbers);
        
        }   

        [HttpGet("users")]  
        public IActionResult Users()
        {
            User person1 = new User()
            {
                FirstName = "Nick",
                LastName = "Cage"
            };
            User person2 = new User()
            {
                FirstName = "Mike",
                LastName = "Walrus"
            };
            User person3 = new User()
            {
                FirstName = "Peter",
                LastName = "Pan"
            };
            User person4 = new User()
            {
                FirstName = "King",
                LastName = "David"
            };

            List<User> Users = new List<User>()
            {
                person1, person2, person3, person4
            };
            return View("Users", Users);
        }  

        [HttpGet("user")] 
        public IActionResult User()
        {
            User someUser = new User()
            {
                FirstName= "Nick",
                LastName= "Cage"
            };
            return View("user", someUser);
        }
    }
}
