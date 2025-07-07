using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Dapperproduct.Model;
namespace Dapperproduct
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            //This is a simple console application to demonstrate Dapper ORM with a SQL Server database.

            //select * from product

            Console.WriteLine("Dapper example");
            ProductService PS = new ProductService();
            List<Product> products = PS.getAllProducts();
            foreach (Product product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
            Console.WriteLine("for getting element by Id please enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Product ById = PS.getProductById(id);
            Console.WriteLine($"the requested element is : \n Name :{ById.Name} \n Price : {ById.Price}");

            // insert product
            //Console.WriteLine("for adding product please enter ID Name Price  : ");
            //int id1 = Convert.ToInt32(Console.ReadLine());
            //string name = Console.ReadLine();
            //double price = Convert.ToDouble(Console.ReadLine());
            //Product newProduct = new Product
            //{
            //    Id = id1,
            //    Name = name,
            //    Price = price
            //};
            //PS.addProduct(newProduct);
            //Console.WriteLine("Product added successfully!");
            //List<Product> updateedProduct = PS.getAllProducts();
            //foreach (var item in updateedProduct)
            //{
            //    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}");
            //}

            //delete product
            //Console.WriteLine("enter product Id to deleted the product: ");
            //int Did = Convert.ToInt32(Console.ReadLine());
            //if (PS.delProduct(Did))
            //{
            //    Console.WriteLine("Product deleted successfully!");
            //    List<Product> updatedProduct = PS.getAllProducts();
            //    foreach (var item in updatedProduct)
            //    {
            //        Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Product not found or could not be deleted.");
            //}

            //update product
            Console.WriteLine("enter the id and new price to update the product : ");
            int pId = Convert.ToInt32(Console.ReadLine());
            double price    = Convert.ToDouble(Console.ReadLine());
            if (PS.upProduct(pId,price))
            {
                Console.WriteLine("Updated product successully!");
                List<Product> updatedProduct = PS.getAllProducts();
                foreach (var item in updatedProduct)
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}");
                }
            }
            else
            {
                Console.WriteLine("updation Failed");
            }
        }
    }
}
