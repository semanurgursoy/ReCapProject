using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description + " : " + car.DailyPrice);
            //}

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description + "\t: " + item.DailyPrice);
            }

            Car car = new Car();
            car.ColorId = 1; 
            car.BrandId = 3; 
            car.DailyPrice = 110000; 
            car.ModelYear = "2016"; 
            car.Description = "BMW";

            carManager.Add(car);
            car.DailyPrice = 150000;
            carManager.Update(car);
            Console.WriteLine();
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description + "\t: " + item.DailyPrice);
            }
            
        }
    }
}
