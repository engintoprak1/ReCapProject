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
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
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
        

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
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
            return new SuccessDataResult<CarForDetailDto>(_carDal.GetCarDetailById(id));
        }
    }
}
