using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Process the valid model (e.g., save to database)
                return RedirectToAction("Index","Home");
            }
            // If the model is not valid, return to the view with validation errors
            return View(person);
        }
    }
}
