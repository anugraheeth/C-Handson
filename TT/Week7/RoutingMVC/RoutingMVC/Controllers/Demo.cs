using Microsoft.AspNetCore.Mvc;

namespace RoutingMVC.Controllers
{
    
    public class Demo : Controller
    {
        [Route("demo/index")] // same as [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("demo/about")] // same as [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("demo/test/{id:int}")] // same as [HttpGet("test/{id:int}")]
        public IActionResult Test(int id)
        {
            return Content($"Test method called with id: {id}");
        }

        [Route("demo/test/{name}")] // same as [HttpGet("test/{name:alpha}")]
        public IActionResult Test(string name)
        {
            return Content($"Test method called with name: {name}");
           
        }

        //Example of a route with constraints

        [Route("demo/age/{age:int:max(35):min(10)}")] // same as [HttpGet("age/{age:int:max(35):min(10)}")]
        public IActionResult Age(int age)
        {
            return Content($"Age method called with age: {age}");
        }


    }
}
