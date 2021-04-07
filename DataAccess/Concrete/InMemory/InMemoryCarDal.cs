using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car> {
            new Car
                { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 200000, Description = "BMW-Beyaz", ModelYear = "2020" },
            new Car
                { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 220000, Description = "Audi-Siyah", ModelYear = "2019" },
            new Car
                { Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 250000, Description = "Mercedes-Mavi", ModelYear = "2018" }
        };

        public List<Car> GetAll()
        {
            return _cars;
        }
        public Car GetById(int id)
        {
            return _cars.Find(s => s.Id == id);
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Araba ekleme işlemi başarılı..");
        }
        public void Delete(Car car)
        {
            var tempCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(tempCar);
            Console.WriteLine("Araba silme işlemi başarılı..");
        }
        public void Update(Car car)
        {
            var tempCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            tempCar.BrandId = car.BrandId;
            tempCar.ColorId = car.ColorId;
            tempCar.ModelYear = car.ModelYear;
            tempCar.DailyPrice = car.DailyPrice;
            tempCar.Description = car.Description;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
