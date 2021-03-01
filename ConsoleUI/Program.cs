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


            //BrandManager brandManager = new BrandManager(new EfBrandDal());
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


            //ColorManager colorManager = new ColorManager(new EfColorDal());
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


            foreach (var item in carManager.GetCarDetail().Data)
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }




            //CustomerTest();
            //UserTest();
            RentalTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { CompanyName = "Asus" };
            customerManager.Add(customer);
            customer.CompanyName = "Dell";
            customerManager.Update(customer);
            Console.WriteLine(customerManager.GetById(2));
            customerManager.Delete(customer);
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0}\t{1}",item.Id,item.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "Elrond", LastName = "Efendi", Email = "elrond@gmail.com", Password = "elrond123" };
            userManager.Add(user);
            user.Password = "@yrıkv@di";
            userManager.Update(user);
            Console.WriteLine(userManager.GetById(4));
            userManager.Delete(user);
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("{0}\t{1}", item.Id, item.LastName);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CustomerId = 2, CarId = 5, RentDate = new DateTime(3020, 01, 01), ReturnDate = new DateTime(3021, 01, 01) };
            rentalManager.Add(rental);
            rental.ReturnDate=new DateTime(3025,01,01);
            rentalManager.Update(rental);
            Console.WriteLine(rentalManager.GetById(2).Data.CarId);
            rentalManager.Delete(rental);
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0}\t{1}", item.CarId, item.ReturnDate);
            }
        }
    }
}
