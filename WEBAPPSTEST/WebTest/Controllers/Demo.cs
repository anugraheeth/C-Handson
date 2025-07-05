using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers
{
    public class Demo : Controller
    {
        public IActionResult About()
        {
            ViewBag.Message = "This is the About page.";
            return View();
        }

        public IActionResult Greet(string name)
        {
            ViewBag.Message = $"Hello, {name}!";
            return View();
        }

        public IActionResult Calculate(int a, int b)
        {
            ViewBag.Result = a + b;
            return View();
        }

        public IActionResult GetFlowers()
        {
            ViewData["Flowers"] = new string[] { "Rose", "Tulip", "Daisy", "Sunflower" };
            return View();
        }
    }
}
