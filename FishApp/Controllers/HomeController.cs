using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FishApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace FishApp.Controllers
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

        [HttpGet("registration")]
        public IActionResult Registration()
        {
            return View("Registration");
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
                return View("Registration");
            }
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("signin")]
        public IActionResult Signin(string LoginEmail, string LoginPassword)
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
                    return View("Login");
                }
           }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }

        [HttpGet("allposts")]
        public IActionResult AllPosts()
        {
            if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = dbContext.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("id"));
            List<Catch> catchList = dbContext.Catches
                                    .Include(a => a.Creator)
                                    .OrderBy(a => a.Date)
                                    .ToList();
            // List<Like> userLikes = dbContext.Likes.Where(a => a.User == currentUser).ToList();
            ViewBag.Id = HttpContext.Session.GetInt32("id"); 
            ViewBag.CurrentUser = currentUser;
            ViewBag.CatchList = catchList;
            // ViewBag.Likes = userLikes;   
            return View("AllPosts");
        }

        [HttpGet("addpost")]
        public IActionResult AddPost()
        {
            if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserId = HttpContext.Session.GetInt32("id");
            return View("AddPost");
        }
        [HttpPost("log")]
        public IActionResult Log(Catch Catch, IFormFile file)
        {
            if(HttpContext.Session.GetInt32("id")== null)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                
                dbContext.Add(Catch);
                dbContext.SaveChanges();
                UploadFile(file,Catch.CatchId);
                dbContext.SaveChanges();
                return RedirectToAction("AllPosts");
            }
            else
            {
                return View("AddPost");
            }
            
        }

        public void UploadFile(IFormFile file, int catchId)
        {
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images",fileName);
            using(var fileStream = new FileStream(path,FileMode.Create)){
                file.CopyTo(fileStream);
            }
            var myCatch = dbContext.Catches.FirstOrDefault(x=>x.CatchId == catchId);
            myCatch.Img = fileName;
            dbContext.Update(myCatch);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
