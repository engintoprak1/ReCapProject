using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IUploadService _uploadService;

        public CarImageManager(ICarImageDal carImageDal, IUploadService uploadService)
        {
            _carImageDal = carImageDal;
            _uploadService = uploadService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImageForAddDto carImageForAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarImageLimitExceeded(carImageForAddDto.CarId)
                );
            if (result != null)
            {
                return result;
            }

            CarImage carImage = new CarImage();
            carImage.CarId = carImageForAddDto.CarId;
            carImage.ImagePath = _uploadService.Add(carImageForAddDto.Image);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);
            _uploadService.Remove(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarHasImage(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>() { new CarImage { ImagePath = "default.png" } });
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id == carImageId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImageForUpdateDto carImageForUpdateDto)
        {
            var carImage = _carImageDal.Get(c => c.Id == carImageForUpdateDto.Id);
            string newPath = _uploadService.Update(carImage.ImagePath,carImageForUpdateDto.Image);
            carImage.ImagePath = newPath;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarHasImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count <= 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
