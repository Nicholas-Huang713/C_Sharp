using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace LoginReg.Controllers
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
                    return RedirectToAction("Success");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("signin")]
        public IActionResult Signin(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                var dbUser = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                if(dbUser == null)
                {
                    ModelState.AddModelError("LoginEmail","Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, dbUser.Password, userSubmission.LoginPassword);
                if(result==0)
                {
                    ModelState.AddModelError("LoginEmail","Invalid Email/Password");
                    return View("Login");
                }                
                HttpContext.Session.GetInt32("id");
                HttpContext.Session.SetInt32("id", dbUser.UserId);
                return RedirectToAction("Success");
                
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetString("id")== null)
            {
                return RedirectToAction("Index");
            }
            // List<User> users = dbContext.Users.ToList();
            return View("Success");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
