using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProductADO
{

    // This class is currently empty, but it can be used to implement methods for product data access.

    public interface IProductRepo
    {
        // Define methods for product data access here, e.g.:
        void Add(Product product);
        void Update(Product product);

        void Delete(int productId);

        Product? GetById(int product);

        IEnumerable<Product> GetAll();

        void CloseConnection();
    }
    public class ProductRepo : IProductRepo
    {

        public readonly string connection = "Data Source = Anugraheeths_PC\\SQLEXPRESS;"+
                                            "Initial Catalog = Product;"+
                                            "Integrated Security = True;"+
                                            "Trust Server Certificate = true;";
        SqlConnection connect = null;// constructor for initializing the connection
        SqlCommand command = null;// command for executing SQL queries

        public ProductRepo()
        {
            connect = new SqlConnection(connection);// Initialize the connection
            connect.Open(); // Open the connection
        }

        public void Add(Product product)
        {
            // Implementation for adding a product
            try
            { 
                string addQuery = "insert into Product values (@id, @name, @price, @stock)";
                command = new SqlCommand(addQuery, connect);        
                command.Parameters.AddWithValue("@id", product.id);// Use AddWithValue to add parameters to the command
                command.Parameters.AddWithValue("@name", product.name ?? (object)DBNull.Value); // Handle null values for string parameters using DBNull.Value
                command.Parameters.AddWithValue("@price", product.price ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@stock", product.stock ?? (object)DBNull.Value);

                int rowsAffected = command.ExecuteNonQuery(); // Execute the command

            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Update(Product product)
        {
            // Implementation for updating a product
            try
            {
                if(!connect.State.HasFlag(System.Data.ConnectionState.Open))
                {
                    connect.Open(); // Ensure the connection is open
                }
                string updateQuery = "UPDATE Product SET name = @name,price=@price,stock=@stock WHERE id = @id";
                command = new SqlCommand(updateQuery, connect);
                command.Parameters.AddWithValue("@id",product.id);
                command.Parameters.AddWithValue("@name", product.name ?? (object)DBNull.Value); // Handle null values for string parameters using DBNull.Value
                command.Parameters.AddWithValue("@price", product.price ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@stock", product.stock ?? (object)DBNull.Value);
                int rowaffected = command.ExecuteNonQuery(); // Execute the command
                if(rowaffected > 0)
                {
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("No product found with the specified ID.");
                }

            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public void Delete(int productId)
        {
            // Implementation for deleting a product
            try
            { 
                string deleteQuery = "delete from product where id =@id";
                command = new SqlCommand(deleteQuery, connect);
                command.Parameters.AddWithValue("@id", productId);
                int rowsAffected = command.ExecuteNonQuery(); // Execute the command

            if(rowsAffected > 0)
                {
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No product found with the specified ID.");
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public Product? GetById(int id )
        {
            // Implementation for getting a product by ID
            try
            {
                Product? product = null; // Initialize product to null because we will return null if not found
                string getByIdQuery = "SELECT * FROM Product WHERE id = @id";
                command = new SqlCommand(getByIdQuery, connect);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            product = new Product
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id")),//getOrdinal retrieves the index of the column by name
                                name = reader.GetString(reader.GetOrdinal("name")),
                                price = reader.GetInt32(reader.GetOrdinal("price")),
                                stock = reader.GetInt32(reader.GetOrdinal("stock"))

                            };

                            return product; // Return the product if found
                        }
                    }
                }
                
            
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
            return null; // Placeholder return because we need to return a Product object
        }

        public IEnumerable<Product> GetAll()
        {
            // Implementation for getting all products
            List<Product> products = new List<Product>();
            try
            {
                string getAllQuery = "SELECT * FROM Product";
                command = new SqlCommand(getAllQuery, connect);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                price = reader.IsDBNull(reader.GetOrdinal("price")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("price")),
                                stock = reader.IsDBNull(reader.GetOrdinal("stock")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("stock"))
                            };
                            products.Add(product); // Add the product to the list
                        }
                        return products; // Return the list of products
                    }
                    else
                    {
                        Console.WriteLine("No products found.");
                    }
                }
                
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
            return null; // Placeholder return
        }

        public void CloseConnection()
        {
            // Implementation for closing the connection
            if (connect != null && connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close(); // Close the connection
                Console.WriteLine("Connection closed successfully.");
            }
        }
    }

}
