using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetCarsByBrandId(int id);
        Car GetCarsByColorId(int id);
        Car GetById(int id);
        List<CarDetailDto> GetCarDetail();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
