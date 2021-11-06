using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImageForAddDto carImageForAddDto);
        IResult Update(CarImageForUpdateDto carImageForUpdateDto);
        IResult Delete(int id);
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
