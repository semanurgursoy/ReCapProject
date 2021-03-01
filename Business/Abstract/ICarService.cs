using Core.Utilities;
using Core.Utilities.DataResult;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarsByBrandId(int id);
        IDataResult<Car> GetCarsByColorId(int id);
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
