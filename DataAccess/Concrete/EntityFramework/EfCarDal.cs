using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        
        public List<CarForListingDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                
            var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                                 on c.ColorId equals color.Id
                                 
                             select new CarForListingDto { Id = c.Id, BrandName = b.BrandName, ModelName = c.ModelName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice,Image = context.CarImages.Where(i=>i.CarId==c.Id).FirstOrDefault(),AvailableForRent = !context.Rentals.Any(r=>r.ReturnDate==null)};
                return result.ToList();
            }
        }
        public CarForDetailDto GetCarDetailById(int id)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join color in context.Colors
                        on c.ColorId equals color.Id
                    where c.Id == id
                    select new CarForDetailDto() { Id = c.Id, BrandName = b.BrandName, ModelName = c.ModelName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, Images = context.CarImages.Where(i => i.CarId == c.Id).ToList(), ModelYear = c.ModelYear };
                return result.FirstOrDefault();
            }
        }


        public List<CarForListingDto> GetCarDetailsByBrandId(int id)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.Id
                             join color in context.Colors
                                 on c.ColorId equals color.Id
                             where c.BrandId == id
                             select new CarForListingDto { Id = c.Id, BrandName = b.BrandName, ModelName = c.ModelName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, Image = context.CarImages.Where(i => i.CarId == c.Id).FirstOrDefault() };
                return result.ToList();
            }
        }

        public List<CarForListingDto> GetCarDetailsByColorId(int id)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.Id
                             join color in context.Colors
                                 on c.ColorId equals color.Id
                             where c.ColorId == id
                             select new CarForListingDto { Id = c.Id, BrandName = b.BrandName, ModelName = c.ModelName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, Image = context.CarImages.Where(i => i.CarId == c.Id).FirstOrDefault() };
                return result.ToList();
            }
        }

        public List<CarForListingDto> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.Id
                             join color in context.Colors
                                 on c.ColorId equals color.Id
                             where c.ColorId == colorId && c.BrandId == brandId
                             select new CarForListingDto { Id = c.Id, BrandName = b.BrandName, ModelName = c.Description, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, Image = context.CarImages.Where(i => i.CarId == c.Id).FirstOrDefault() };
                return result.ToList();
            }
        }
    }
}
