 using Microsoft.AspNetCore.Mvc;
    namespace testproj.Controllers     //be sure to use your own project's namespace!
    {
        public class HelloController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            // [HttpGet]       //type of request
            // [Route("")]     //associated route string (exclude the leading /)
            // public JsonResult Example()
            // {
            //     return Json(10);
            // }

            // [HttpGet]
            // [Route("displayint")]
            // public JsonResult DisplayInt()
            // {
            //     return Json(34);
            // }

            // [HttpGet]
            // [Route("displayanon")]
            // public JsonResult DisplayAnon()
            // {
            //     var AnonObject = new {
            //         FirstName = "Raz",
            //         LastName = "Aquato",
            //         Age = 10
            //     };
                
            //     return Json(AnonObject);
            // }

            [HttpGet("")]
            public ViewResult Index()
            {
                // ViewBag.Example = "Yo!";
                return View();
            }

            // [HttpGet]
            // [Route("info")]
            // public ViewResult Info()
            // {
            //     // Same logic for serving a view applies
            //     // if we provide the the exact view name
            //     return View("Info");
            // }

            // [HttpGet("elsewhere")]
            // public ViewResult Elsewhere()
            // {
            //     return View("Index");
            // }

            // [HttpGet("method")]
            // public RedirectToActionResult Method()
            // {
            //     // return RedirectToAction("Elsewhere");
            //     return RedirectToAction("OtherMethod", new { Food = "sandwiches", Quantity = 5 });
            // }

            // public ViewResult OtherMethod()
            // {
            //     return View();
            // }

        
            // [HttpGet]
            // [Route("other/{Food}/{Quantity}")]
            // public string OtherMethod(string Food, int Quantity)
            // {
            //     return $"{Food}, {Quantity}";
            // }
        }
    }
