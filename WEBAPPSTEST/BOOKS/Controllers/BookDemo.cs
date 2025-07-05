using Microsoft.AspNetCore.Mvc;
using BOOKS.Models;

namespace BOOKS.Controllers
{
    public class BookDemo : Controller
    {
        public IActionResult Index()
        {
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "C# Programming", Author = "John Doe", Price = 29.99 },
                new Book { Id = 2, Title = "ASP.NET Core", Author = "Jane Smith", Price = 39.99 },
                new Book { Id = 3, Title = "Entity Framework Core", Author = "Alice Johnson", Price = 49.99 }
            };
            return View();
        }
        public IActionResult Details()
        {
            Book book = new Book()
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                Price = 29.99
            };
            return View(book);
        }
    }
}
