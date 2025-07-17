using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet] //it is compulsory to specify the HTTP method for every action method
        public IActionResult Get() //any return type is fine but IActionResult is common because it allows for flexibility in the response type
        {

            return Ok("Hello from MyAPI2!");// this returns a 200 OK response with the specified message
        }

        //[HttpGet]
        //this will create ambiguity with the previous method since both methods have the same HTTP method and route
        // it is not recommended to have two methods with the same HTTP method and route
        //so we will change the name of this method to avoid ambiguity

        [HttpGet("get2")] // this will create a new route for this method or you can use [httpGet("get2")] to specify the route directly
        //[Route("get2")] // this will create a new route for this method but it is not recommended to use Route attribute with HttpGet attribute
        //because swagger will not be able to generate the documentation for this method
        public IActionResult Get2() // this method has a typo in the access modifier
        {
            return Ok("Hello from MyAPI2! - Get2");
        }

    }
}
