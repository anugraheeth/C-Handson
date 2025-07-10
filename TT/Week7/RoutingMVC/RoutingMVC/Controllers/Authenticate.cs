using Microsoft.AspNetCore.Mvc;

namespace RoutingMVC.Controllers
{
    [Route("auth")]
    public class Authenticate : Controller
    {

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            //return RedirectToAction("Index", "Home");//used to redirect to Home controller's Index action using named route
            return Redirect("Login");//used to redirect to Login action in the same controller using relative path
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
