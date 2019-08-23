using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wedding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace Wedding.Controllers
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
            return View();
        }

       [HttpPost("register")]
       public IActionResult Register(User user)
       {
           if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                } 
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    dbContext.Add(user);
                    dbContext.SaveChanges();

                    var dbUser = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

                    HttpContext.Session.GetInt32("id");
                    HttpContext.Session.SetInt32("id", dbUser.UserId);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("Index");
            }
       }
       [HttpGet("dashboard")]
       public IActionResult Dashboard()
       {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            List<Plan> weddingList = dbContext.Plans
                                    .Include(wedding => wedding.Guests)
                                    .ThenInclude(guests => guests.User)
                                    .ToList();
            List<Rsvp> userRsvps = dbContext.Rsvps.Where(rsvp => rsvp.User == currentUser).ToList();
            ViewBag.Id = HttpContext.Session.GetInt32("id");
            ViewBag.CurrentUser = currentUser;
            ViewBag.WeddingList = weddingList;
            ViewBag.Rsvps = userRsvps;
            return View("Dashboard");
       }

       [HttpPost("login")]
       public IActionResult Login(string LoginEmail, string LoginPassword)
       {
           var dbUser = dbContext.Users.FirstOrDefault(u => u.Email == LoginEmail);
           if(dbUser == null)
           {
               ViewBag.Error = "Email not registered";
               return View("Index");
           }
           else
           {
               var Hasher = new PasswordHasher<User>();
               if(0 != Hasher.VerifyHashedPassword(dbUser, dbUser.Password, LoginPassword)) {
                    HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                    HttpContext.Session.GetInt32("id");
                    HttpContext.Session.SetInt32("id", dbUser.UserId);
                    return RedirectToAction("Dashboard");
                }
                else {
                    ViewBag.Error = "Incorrect Password";
                    return View("Index");
                }
           }
       }
       [HttpGet("new")]
       public IActionResult New()
       {
           ViewBag.UserId = HttpContext.Session.GetInt32("id");
           return View("New");
       }

       [HttpPost("create")]
       public IActionResult Create(Plan plan)
       {
           if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
           if(ModelState.IsValid)
            {
                dbContext.Add(plan);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("New");
            }
       }

       [HttpGet("show/{id}")]
        public IActionResult Show(int id)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            var thisWedding = dbContext.Plans
                              .Include(wedding => wedding.Guests)
                              .ThenInclude(guest => guest.User)
                              .FirstOrDefault(wedding => wedding.PlanId == id);
            // ViewBag.CurrentWedding = thisWedding;
            return View("Show", thisWedding);
        }

        [HttpGet("rsvp/{weddingId}")]
        public IActionResult Rsvp(int weddingId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            Plan currentWedding = dbContext.Plans.
                                  Include(wedding => wedding.Guests)
                                  .ThenInclude(guest => guest.User)
                                  .SingleOrDefault(wedding=> wedding.PlanId == weddingId);
            Rsvp newRsvp = new Rsvp{
                User_Id = currentUser.UserId,
                User = currentUser,
                WeddingId = currentWedding.PlanId,
                Wedding = currentWedding
            };
            currentWedding.Guests.Add(newRsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("cancel/{weddingId}")]
        public IActionResult Cancel(int weddingId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            Plan currentWedding = dbContext.Plans.
                                  Include(wedding => wedding.Guests)
                                  .ThenInclude(guest => guest.User)
                                  .SingleOrDefault(wedding=> wedding.PlanId == weddingId);
            Rsvp currentRsvp = dbContext.Rsvps.FirstOrDefault(rsvp => rsvp.User_Id == HttpContext.Session.GetInt32("id"));
            currentWedding.Guests.Remove(currentRsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard"); 
        }

        [HttpGet("delete/{weddingId}")]
        public IActionResult Delete(int weddingId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            Plan currentWedding = dbContext.Plans.SingleOrDefault(wedding => wedding.PlanId == weddingId);
            dbContext.Plans.Remove(currentWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
            
        }

       [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
