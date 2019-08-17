using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoDachi.Models;
using Microsoft.AspNetCore.Http;
using DojoDachi.Extensions;

namespace DojoDachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           
            HttpContext.Session.SetInt32("fullness", 20);
        
            HttpContext.Session.SetInt32("happiness", 20);
        
            HttpContext.Session.SetInt32("meals", 3);

            HttpContext.Session.SetInt32("energy", 50);
            
            int? energy = HttpContext.Session.GetInt32("energy");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if(energy >= 100 && fullness >= 100 && happiness >= 100)
            {
                HttpContext.Session.SetString("message", "Congratulations! You won!");
            }


            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");
            ViewBag.Message = HttpContext.Session.GetString("message");

            return View();
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            

            if(HttpContext.Session.GetInt32("meals") == 0)
            {
                HttpContext.Session.SetString("message", "You're all out of meals!");
            }
            else
            {
                if(energy >= 100 && fullness >= 100 && happiness >= 100)
                {
                    HttpContext.Session.SetString("message", "Congratulations! You won!");
                }
                else
                {
                    var random = new Random();
                    int randInt = random.Next(1,4);
                    if(randInt== 1)
                    {
                        meals--;
                        HttpContext.Session.SetInt32("meals", (int)meals); 
                        HttpContext.Session.SetString("message", "Drogon rejected your meal...");
                    }
                    else
                    {
                        meals--;
                        HttpContext.Session.SetInt32("meals", (int)meals); 
                        int randVal = random.Next(5,10);
                        fullness += randVal;
                        HttpContext.Session.SetInt32("fullness", (int)fullness); 
                        HttpContext.Session.SetString("message", $"You fed Drogon! Fullness + {randVal}, Meals - 1");
                    } 
                }
                
            }

            ViewBag.Message = HttpContext.Session.GetString("message");
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");

            return View("Index");
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? fullness = HttpContext.Session.GetInt32("fullness");

            if(HttpContext.Session.GetInt32("energy") == 0)
            {
                HttpContext.Session.SetString("message", "You do not have enough energy!");
            }
            else
            {
                if(energy >= 100 && fullness >= 100 && happiness >= 100)
                {
                    HttpContext.Session.SetString("message", "Congratulations! You won!");
                }
                else
                {
                    var random = new Random();
                    int randInt = random.Next(1,4);
                    if(randInt== 1){
                        energy -= 5;
                        HttpContext.Session.SetInt32("energy", (int)energy); 
                        HttpContext.Session.SetString("message", "Drogon doesn't wanna play....");
                    }
                    else{
                        energy -= 5;
                        int randVal = random.Next(5,10);
                        happiness += randVal;
                        HttpContext.Session.SetInt32("energy",  (int)energy);
                        HttpContext.Session.SetInt32("happiness",  (int)happiness);
                        HttpContext.Session.SetString("message", $"You played with Drogon! Happiness +{randVal}, Energy -5");
                    }
                }
                
            }
            ViewBag.Message = HttpContext.Session.GetString("message");
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");
            return View("Index");
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");

            if(HttpContext.Session.GetInt32("energy") == 0)
            {
                HttpContext.Session.SetString("message", "You do not have enough energy!");
            }
            else{
                energy -= 5;
                var random = new Random();
                int randVal = random.Next(1,3);
                meals += randVal;
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetString("message", $"Sent Drogon to work! Meals +{randVal}, Energy -5");
            }
            ViewBag.Message = HttpContext.Session.GetString("message");
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");
            return View("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            if(fullness <= 0 || happiness <= 0){
                HttpContext.Session.SetString("message", "No more fullness or happiness left...");
            }
            else
            {
                
                if(energy >= 100 && fullness >= 100 && happiness >= 100)
                {
                    HttpContext.Session.SetString("message", "Congratulations! You won!");
                }
                else
                {
                    energy += 15;
                    fullness -= 5;
                    happiness -=5;

                    HttpContext.Session.SetInt32("energy", (int)energy);
                    HttpContext.Session.SetInt32("fullness", (int)fullness);
                    HttpContext.Session.SetInt32("happiness", (int)happiness);
                    HttpContext.Session.SetString("message", "Put Drogon to sleep. ZZZZZ... Energy +15, Fullness -5, Happiness -5");
                }
                
            }
           
            ViewBag.Message = HttpContext.Session.GetString("message");
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");
            return View("Index");
        }
    }
}
