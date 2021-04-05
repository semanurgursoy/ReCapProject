using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join cu in context.Customers
                             on r.CustomerId equals cu.Id

                             join b in context.Brands
                             on c.BrandId equals b.Id

                             join u in context.Users
                             on cu.Id equals u.Id

                             select new RentalDetailDto { 
                                 Id = r.Id, 
                                 BrandName = b.Name, 
                                 DailyPrice = c.DailyPrice, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
