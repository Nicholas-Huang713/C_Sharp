using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Activity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Activity.Controllers
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

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            List<ThisActivity> activityList = dbContext.Activities
                                    .Include(a=> a.Coordinator)
                                    .Include(a => a.Participants)
                                    .ThenInclude( a => a.User)
                                    .OrderBy(a => a.Date)
                                    .ToList();
            List<ThisAction> userActions = dbContext.Actions.Where(a => a.User == currentUser).ToList();
            ViewBag.Id = HttpContext.Session.GetInt32("id");
            ViewBag.CurrentUser = currentUser;
            ViewBag.ActivityList = activityList;
            ViewBag.UserActions = userActions;
            return View("Dashboard");
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserId = HttpContext.Session.GetInt32("id");
            var dbUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("id"));
            ViewBag.Coordinator = dbUser;
            return View("New");
        }

        [HttpPost("create")]
        public IActionResult Create(ThisActivity activity)
        {
            if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
           if(ModelState.IsValid)
            {
                dbContext.Add(activity);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("show/{activityId}")]
        public IActionResult Show(int activityId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            var thisActivity = dbContext.Activities
                              .Include(a => a.Coordinator)
                              .Include(a => a.Participants)
                              .ThenInclude(p => p.User)
                              .FirstOrDefault(a => a.ThisActivityId == activityId);
            var coordinator = dbContext.Activities.Include(a => a.Coordinator)
                                  .FirstOrDefault(a => a.ThisActivityId == activityId);
            ViewBag.Coordinator = coordinator;
            return View("Show", thisActivity);
        }

        [HttpGet("join/{activityId}")]
        public IActionResult Join(int activityId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            ThisActivity currentActivity = dbContext.Activities.
                                  Include(a => a.Participants)
                                  .ThenInclude(p => p.User)
                                  .SingleOrDefault(a=> a.ThisActivityId == activityId);
            ThisAction newAction = new ThisAction{
                UserId = currentUser.UserId,
                User = currentUser,
                ThisActivityId = currentActivity.ThisActivityId,
                ThisActivity = currentActivity
            };
            currentActivity.Participants.Add(newAction);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("leave/{activityId}")]
        public IActionResult Leave(int activityId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            ThisActivity currentActivity = dbContext.Activities.
                                  Include(a => a.Participants)
                                  .ThenInclude(p => p.User)
                                  .SingleOrDefault(a=> a.ThisActivityId == activityId);
            ThisAction currentAction = dbContext.Actions.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("id") && a.ThisActivityId == activityId);             
            currentActivity.Participants.Remove(currentAction);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{activityId}")]
        public IActionResult Delete(int activityId)
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            ThisActivity currentActivity = dbContext.Activities.SingleOrDefault(a => a.ThisActivityId == activityId);
            dbContext.Activities.Remove(currentActivity);
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
