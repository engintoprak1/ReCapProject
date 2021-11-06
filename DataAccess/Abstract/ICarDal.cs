using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarForDetailDto GetCarDetailById(int id);
        List<CarForListingDto> GetCarDetails();
        List<CarForListingDto> GetCarDetailsByBrandId(int id);
        List<CarForListingDto> GetCarDetailsByColorId(int id); 
        List<CarForListingDto> GetCarDetailsByBrandAndColorId(int brandId, int colorId);
    }
}
