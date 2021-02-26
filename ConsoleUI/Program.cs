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
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description + "\t: " + item.DailyPrice);
            //}

            //Car car = new Car();
            //car.ColorId = 2; 
            //car.BrandId = 2; 
            //car.DailyPrice = 310000; 
            //car.ModelYear = "2019"; 
            //car.Description = "Mercedes";

            //carManager.Add(car);
            //car.DailyPrice = 350000;
            //carManager.Update(car);
            //Console.WriteLine();
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description + "\t: " + item.DailyPrice);
            //}
            //Console.WriteLine(carManager.GetById(3));
            //carManager.Delete(car);
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description + "\t: " + item.DailyPrice);
            //}


            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var item in brandManager.GetAll())
            //{
            //    Console.WriteLine("{0} - {1}",item.Id,item.Name);
            //}

            //Brand brand = new Brand();
            //brand.Name = "Vosvogen";

            //brandManager.Add(brand);
            //brand.Name = "Volvo";
            //brandManager.Update(brand);
            //Console.WriteLine();
            //foreach (var item in brandManager.GetAll())
            //{
            //    Console.WriteLine("{0} - {1}", item.Id, item.Name);
            //}
            //Console.WriteLine("\n"+brandManager.GetById(2).Name+"\n");
            //brandManager.Delete(brand);
            //foreach (var item in brandManager.GetAll())
            //{
            //    Console.WriteLine("{0} - {1}", item.Id, item.Name);
            //}


            ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0} - {1}", item.Id, item.Name);
            //}

            //Color color = new Color();
            //color.Name = "Grey";

            //colorManager.Add(color);
            //color.Name = "Yellow";
            //colorManager.Update(color);
            //Console.WriteLine();
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0} - {1}", item.Id, item.Name);
            //}
            //Console.WriteLine("\n" + colorManager.GetById(5).Name + "\n");
            //colorManager.Delete(color);
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0} - {1}", item.Id, item.Name);
            //}


            foreach(var item in carManager.GetCarDetail())
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3}",item.CarName,item.BrandName,item.ColorName,item.DailyPrice);
            }
        }
    }
}
