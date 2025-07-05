using Microsoft.Data.SqlClient;

namespace MovieADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=Anugraheeths_PC\\SQLEXPRESS;" +
                                      "Initial Catalog=MovieDB;Integrated Security=True;" +
                                      "Trust Server Certificate=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection Opened Successfully");
                
                string query = "SELECT * FROM Movie";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["MovieId"]}, Title: {reader["MovieName"]}, ReleaseYear: {reader["ReleaseYear"]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                connection.Close();
                Console.WriteLine("Connection Closed");
            }
        }
    }
}
