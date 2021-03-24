using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.DataResult;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));
            if (result != null)
                return result;
            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddedCarImage);
        }

        public IResult Delete(CarImage carImage)
        {
            //var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(I => I.Id == carImage.Id).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.DeleteAsync(oldPath));  //klasörden siler
            if (result != null)
                return result;

            _carImageDal.Delete(carImage); //db den siler
            return new SuccessResult(Messages.DeletedCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result != null)
                return new ErrorDataResult<List<CarImage>>(result.Message);
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));
            if (result != null)
                return result;

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.UpdateAsync(oldPath, file);
            carImage.Date = DateTime.Now;
      
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceded(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result >= 5)
                return new ErrorResult(Messages.CarImageLimitExceded);
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage
                    {
                        CarId = id,
                        ImagePath = @"\Images\default.jpg",
                        Date = DateTime.Now
                    });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch(Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==id));
            

        }




    }
}
