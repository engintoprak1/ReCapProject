using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal,ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(CarForAddDto car)
        {


            Car carToAdd = new Car{BrandId=car.BrandId,ModelName=car.ModelName,ColorId = car.ColorId, DailyPrice= car.DailyPrice,ModelYear=car.ModelYear ,Description= car.Description,Findeks=car.Findeks};
            _carDal.Add(carToAdd);
            var imagesToAdd = car.Images.Select(i => new CarImageForAddDto() { CarId = carToAdd.Id, Image = i }).ToList();
            foreach (var image in imagesToAdd)
            {
                _carImageService.Add(image);
            }

            
            

            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(int id)
        {
            var result = _carDal.Get(c=>c.Id == id);
            _carDal.Delete(result);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(CarForUpdateDto car)
        {
            Car carToUpdate = _carDal.Get(c => c.Id == car.Id);
            if (carToUpdate==null)
            {
                return new ErrorResult();
            }
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelName = car.ModelName;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Findeks = car.Findeks;
            _carDal.Update(carToUpdate);
            foreach (var image in _carImageService.GetAllByCarId(carToUpdate.Id).Data)
            {
                _carImageService.Delete(image.Id);
            }
            
            var imagesToUpdate = car.Images.Select(i => new CarImageForAddDto() { CarId = carToUpdate.Id, Image = i }).ToList();
            foreach (var image in imagesToUpdate)
            {
                _carImageService.Add(image);
            }
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed); 
            
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }
        
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarForListingDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarForListingDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarForListingDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarForListingDto>>(_carDal.GetCarDetailsByBrandId(id));
        }


        public IDataResult<List<CarForListingDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarForListingDto>>(_carDal.GetCarDetailsByColorId(id));
        }

        public IDataResult<List<CarForListingDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarForListingDto>>(_carDal.GetCarDetailsByBrandAndColorId(brandId, colorId));
        }

        public IDataResult<CarForDetailDto> GetCarDetailById(int id)
        {
            var result = _carDal.Get(i => i.Id == id);
            if (result == null) return new ErrorDataResult<CarForDetailDto>();
            return new SuccessDataResult<CarForDetailDto>(_carDal.GetCarDetailById(id));
        }

        public IDataResult<int> GetCarFindeks(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            return new SuccessDataResult<int>(result.Findeks);
        }
    }
}
