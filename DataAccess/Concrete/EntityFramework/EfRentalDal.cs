using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join u in context.Users
                             on cus.UserId equals u.Id
                             select new RentalDetailDto { BrandName = b.BrandName,ModelName = c.ModelName,FirstName = u.FirstName, LastName = u.LastName };
                return result.ToList();

            }
        }

        
    }
}
