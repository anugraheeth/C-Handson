using Microsoft.AspNetCore.Mvc;

namespace RoutingMVC.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
