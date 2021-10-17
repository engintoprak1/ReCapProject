using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile formFile);
        IResult Update(IFormFile formFile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
