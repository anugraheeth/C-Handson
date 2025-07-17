using Microsoft.AspNetCore.Mvc;
using MVCAssess.Models;

namespace MVCAssess.Controllers
{
    public class InternController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Intern intern)
        {
            if (ModelState.IsValid)
            {
                if ((intern.Qualification == "Master" || intern.Qualification == "Engineering") && (intern.CGPA >= 8.0))
                {
                    return Json(intern);
                }
                else
                {
                    TempData["Message"] = $"{intern.Name} is not qualified for intership";
                    return View(intern);
                }
            }
            return View(intern);
        }
    }
}
