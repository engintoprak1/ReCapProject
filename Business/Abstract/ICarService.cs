using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(CarForAddDto car);
        IResult Update(CarForUpdateDto car);
        IResult Delete(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarForListingDto>> GetCarDetails();
        IDataResult<List<CarForListingDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarForListingDto>> GetCarsByColorId(int id);
        IDataResult<List<CarForListingDto>> GetCarDetailsByBrandAndColorId(int brandId,int colorId);
        IDataResult<CarForDetailDto> GetCarDetailById(int id);
        IResult AddTransactionalTest(Car car);
    }
}
