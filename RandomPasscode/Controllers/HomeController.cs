using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    using Newtonsoft.Json;
    // public static class SessionExtensions
    // {
    //     public static void SetObjectAsJson(this ISession session, string key, object value)
    //     {
    //         session.SetString(key, JsonConvert.SerializeObject(value));
    //     }

    //     public static T GetObjectFromJson<T>(this ISession session, string key)
    //     {
    //         string value = session.GetString(key);
    //         return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);

    //     }
    // }
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("score")==null)
            {
                HttpContext.Session.SetInt32("score", 0);
            }
            ViewBag.Score = HttpContext.Session.GetInt32("score");
            return View();
        }

        [HttpGet("click")]
        public IActionResult Click()
        {
            if(HttpContext.Session.GetInt32("score")==null)
            {
                HttpContext.Session.SetInt32("score", 1);
            }
            else{
                int? sessionScore = HttpContext.Session.GetInt32("score");
                sessionScore ++;
                HttpContext.Session.SetInt32("score", (int)sessionScore);
            }
            ViewBag.Score = HttpContext.Session.GetInt32("score");

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string stringChars = "";
            var random = new Random();
            for (int i = 0; i< 9; i++){
                stringChars += chars[random.Next(0,chars.Length)];
            }            
            // string finalString = new String(stringChars);
            // HttpContext.Session.SetObjectAsJson("Index", finalString);
            // string Retrieve = HttpContext.Session.GetObjectFromJson<string>("Index");

            return View("Index", stringChars);
        }
    }
}
