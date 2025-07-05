using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstProduct
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //add new product row to the Products table
            var product = new Entities.Product
            {
                Name = "Mobile",
                Price = 30000
            };

            var dbContext = new DBContext.Database();
            //add the product to the Products table

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync(); // This saves the changes to the database
            //display the product details
            var products = await dbContext.Products.ToListAsync();

            foreach (var p in products)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
            }
        }
    }
}
