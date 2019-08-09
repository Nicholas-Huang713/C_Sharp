 using Microsoft.AspNetCore.Mvc;
    namespace portfolio2.Controllers    
    {
        public class MainController : Controller   
        {
            
            [HttpGet]       
            [Route("")]     
            public ViewResult Index()
            {
                return View();
            }

            [HttpGet("projects")]

            public ViewResult Projects()
            {
                return View("Projects");
            }

            [HttpGet("contact")]

            public ViewResult Contact()
            {
                return View("Contact");
            }
        }
    }