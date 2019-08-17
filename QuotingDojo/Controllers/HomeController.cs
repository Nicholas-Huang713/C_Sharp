using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Quote newQuote)
        {
            string query = $"INSERT INTO quotes (Name, MyQuote) VALUES ('{newQuote.Name}', '{newQuote.MyQuote}')";
            DbConnector.Execute(query);
            return RedirectToAction("Show");
        }
        [HttpGet("show")]
        public IActionResult Show()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.Quotes = AllQuotes;
            return View("Show");
        }
    }
        
}
