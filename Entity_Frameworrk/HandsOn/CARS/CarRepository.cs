using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS
{
    public class CarRepository
    {
        public List<Cars> GetallCars()
        {
            using (var context = new CarContext())
            {
                var cars = context.Cars.ToList();
                if(cars.Count == 0)
                {
                    Console.WriteLine("No cars found.");
                    return null;
                }
                else
                {
                    return cars;
                }
            }
        }

        public Cars GetByID(int id)
        {
            using(var context = new CarContext())
            {
                return context.Cars.FirstOrDefault(c=>c.CarId==id);
            }
        }

        public bool AddCar(Cars car)
        {
            using(var context= new CarContext())
            {
                context.Add(car);
                int row = context.SaveChanges();
                if(row > 0) 
                     return true;
                else 
                    return false;
            }
        }
        public bool DeleteCar(int id)
        {
            using(var context = new CarContext())
            {
                var car = context.Cars.FirstOrDefault(c => c.CarId == id);
                context.Cars.Remove(car);
                int row =  context.SaveChanges();
               if (row > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool UpdateCar(double  price,int id)
        {
            using (var context = new CarContext())
            {
                var existingCar = context.Cars.FirstOrDefault(c => c.CarId ==id );
                if (existingCar != null)
                {
                    existingCar.price = price;
                    int row = context.SaveChanges();
                    return row > 0;
                }
                return false;
            }
        }
    }
}
