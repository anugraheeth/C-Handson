using System.Globalization;

namespace CARS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    CarRepository carRepo = new CarRepository();
                    Console.WriteLine("Welcome to the Car Management System!");
                    Console.WriteLine("1. View All Cars");
                    Console.WriteLine("2. Ge Car By ID");
                    Console.WriteLine("3. Add New Car");
                    Console.WriteLine("4. Update Car Price");
                    Console.WriteLine("5. Delete Car");
                    Console.WriteLine("6. Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            
                            var cars = carRepo.GetallCars();
                            if (cars != null)
                            {
                                foreach (var car in cars)
                                {
                                    Console.WriteLine($"ID: {car.CarId}, Brand: {car.Brand}, Model: {car.Model}, Price: {car.price}");
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Car ID:");
                            int carId = Convert.ToInt32(Console.ReadLine());
                            // Logic to get car by ID
                            Cars c = carRepo.GetByID(carId);
                            Console.WriteLine($" ID : {c.CarId}\n Brand : {c.Brand} \n Model : {c.Model}\n Price : {c.price}");
                            break;
                        case 3:
                            Console.WriteLine("Enter Car Details to Add:");
                            // Logic to add new car
                            int cId = Convert.ToInt32(Console.ReadLine());
                            string brand = Console.ReadLine();
                            string model = Console.ReadLine();
                            double price = Convert.ToDouble(Console.ReadLine());
                            Cars newCar = new Cars
                            { 
                                CarId = cId,
                                Brand = brand,
                                Model = model,
                                price = price
                            };
                            if(carRepo.AddCar(newCar))
                            {
                                Console.WriteLine("Car added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("some error occured ");
                            }

                            break;
                        case 4:
                            Console.WriteLine("Enter Car ID to Update Price:");
                            int updateCarId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter New Price:");
                            double newPrice = Convert.ToDouble(Console.ReadLine());
                            // Logic to update car details
                            if (carRepo.UpdateCar(newPrice, updateCarId))
                            {
                                Console.WriteLine("Car updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Car not found or could not be updated.");
                            }
                            break;
                        case 5:
                            // Logic to delete car
                            Console.WriteLine("Enter Car ID to Delete:");
                            int deleteCarId = Convert.ToInt32(Console.ReadLine());
                            if (carRepo.DeleteCar(deleteCarId))
                            {
                                Console.WriteLine("Car deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Car not found or could not be deleted.");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                } while (true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
