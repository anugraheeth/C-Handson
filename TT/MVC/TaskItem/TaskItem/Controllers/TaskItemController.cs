using Microsoft.AspNetCore.Mvc;

namespace TaskItem.Controllers
{
    public class TaskItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: TaskItem/Create
        public IActionResult Create()
        {
            return View();
        }

        //get: TaskItem/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }


        //get: TaskItem/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id <= null)
            {
                return NotFound();
            }
            // Logic to delete the task item would go here
            return View();
        }
    }
}
