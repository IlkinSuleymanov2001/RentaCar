using Business.Abstracts;
using Business.BusinessAspect.Aspect;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstrasts;
using Entities.Concrets;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrets
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal) 
        {
            _carDal = carDal;
        }

       
       
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
  
            _carDal.Add(car);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            return new SuccessResult();
        }

        [CacheAspect(10)]
        [SecuredOperation("user")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        
        public IDataResult<Car> GetById(int id)
        {
            var car = _carDal.Get(car => car.CarId == id);
            if(car!=null)
            { 
             return new SuccessDataResult<Car>();
            }
            return new ErrorDataResult<Car>();
      }

      

        public IResult Update(Car car)
        {
                 _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
