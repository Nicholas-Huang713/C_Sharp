using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chefs.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> chefList = dbContext.Chefs.Include(c => c.CreateDishes).ToList();
            foreach(var chef in chefList)
            {
                System.Console.WriteLine(chef.FirstName);
            }
            return View("Index",chefList);
        }
        
        [HttpGet("newChef")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("addChef")]
        public IActionResult AddChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpGet("allDishes")]
        public IActionResult AllDishes()
        {
            List<Dish> dishList = dbContext.Dishes.Include(c => c.Creator).ToList();
            return View("AllDishes", dishList);
        }
        [HttpGet("newDish")]
        public IActionResult NewDish()
        {
            List<Chef> chefList = dbContext.Chefs.ToList();
            ViewBag.chefs = chefList;
            return View("NewDish");
        }
        [HttpPost("addDish")]
        public IActionResult AddDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("AllDishes");
            }
            else
            {
                List<Chef> chefList = dbContext.Chefs.ToList();
                ViewBag.chefs = chefList;
                return View("NewDish");
            }
        }
        
    }
}
