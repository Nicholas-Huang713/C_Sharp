using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudelicious.Controllers
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
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(d => d.DishId).ToList();
            ViewBag.Dishes = AllDishes;
            return View();
        }
        
        [HttpGet("new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
             if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("New");
            }
            
        }
        [HttpGet("view/{id}")]
        public IActionResult ViewOne(int id)
        {
            Dish oneDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            ViewBag.Dish = oneDish;
            return View("ViewOne");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            return View("Edit", dish);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(int id, Dish updatedDish)
        {
            if(ModelState.IsValid)
            {
                Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
                dish.Name = updatedDish.Name;
                dish.Chef = updatedDish.Chef;
                dish.Tastiness = updatedDish.Tastiness;
                dish.Calories = updatedDish.Calories;
                dish.Description = updatedDish.Description;
                dish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            dbContext.Dishes.Remove(dish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
