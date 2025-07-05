namespace ProductADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Product product = new Product
            //{
            //    id = 2,
            //    name = "Pen",
            //    price = 10,
            //    stock = 50
            //};


            //add a product

            //productRepo.Add(product);

            // Get a product by ID

            //Product? foundProduct = productRepo.GetById(2);
            //if (foundProduct != null)
            //{
            //    Console.WriteLine($"Id: {foundProduct.id}, Name: {foundProduct.name}, Price: {foundProduct.price}, Stock: {foundProduct.stock}");
            //}
            //else
            //{
            //    Console.WriteLine("Product not found.");
            //}

            // Update a product

            //productRepo.Update(product);

            // Delete a product

            //productRepo.Delete(1);

            // Get all products

            //foreach(var item in productRepo.GetAll())
            //{
            //    Console.WriteLine($"Id: {item.id}, Name: {item.name}, Price: {item.price}, Stock: {item.stock}");
            //}

            //using swiutch case    
            try
            {
                do
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add Product");   
                    Console.WriteLine("2. Get Product by ID");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. Delete Product");
                    Console.WriteLine("5. Get All Products");
                    Console.WriteLine("6. Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());   
                    Console.WriteLine("--------------------------------------------------");
                    ProductRepo productRepo = new ProductRepo();
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Product ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Product Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Product Price:");
                            int price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Product Stock:");
                            int stock = Convert.ToInt32(Console.ReadLine());
                            Product product = new Product
                            {
                                id = id,
                                name = name,
                                price = price,
                                stock = stock
                            };
                            productRepo.Add(product);
                            Console.WriteLine("Product added successfully.");
                            Console.WriteLine("--------------------------------------------------");
                            break;
                        case 2:
                            Console.WriteLine("Enter Product ID to retrieve:");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            Product? foundProduct = productRepo.GetById(searchId);
                            if (foundProduct != null)
                            {
                                Console.WriteLine($"Id: {foundProduct.id}, Name: {foundProduct.name}, Price: {foundProduct.price}, Stock: {foundProduct.stock}");
                                Console.WriteLine("--------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                                Console.WriteLine("--------------------------------------------------");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Product ID to update:");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            Product? productToUpdate = productRepo.GetById(updateId);

                            Console.WriteLine("Which attribute to upate:");
                            Console.WriteLine("1. Name");
                            Console.WriteLine("2. Price");
                            Console.WriteLine("3. Stock");
                            int updateChoice = Convert.ToInt32(Console.ReadLine());
                            if(productToUpdate != null)
                            {

                                switch (updateChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter new Name:");
                                        productToUpdate.name = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter new Price:");
                                        productToUpdate.price = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter new Stock:");
                                        productToUpdate.stock = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        continue;
                                }
                                productRepo.Update(productToUpdate);
                                Console.WriteLine("--------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                                Console.WriteLine("--------------------------------------------------");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter Product ID to delete:");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            productRepo.Delete(deleteId);
                            Console.WriteLine("--------------------------------------------------");
                            break;
                         case 5:
                            Console.WriteLine("All Products:");
                            foreach (var item in productRepo.GetAll())
                            {
                                Console.WriteLine($"Id: {item.id}, Name: {item.name}, Price: {item.price}, Stock: {item.stock}");
                            }
                            Console.WriteLine("--------------------------------------------------");
                            break;
                         case 6:
                            Console.WriteLine("Exiting the application.");
                            productRepo.CloseConnection(); // Dispose of the repository to close the connection
                            return;
                         default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operation completed.");
            }
        }
    }
}
