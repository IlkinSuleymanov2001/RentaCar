using Business.Abstracts;
using Business.BusinessAspect.Aspect;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstrasts;
using Entities.Concrets;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrets
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        [SecuredOperation("user")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRule.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageSuccessAdd);
        }

        public Core.Utilities.Results.IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRule.Run(CheckCarImage(carId));
            if (result!= null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data, result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));
        }

        

        public IDataResult<CarImage> GetByImageId(int imageId)
        {

            var data = _carImageDal.Get(ci => ci.Id == imageId);
            if ( data!= null)
            {
                return new SuccessDataResult<CarImage>(data);
            }
            return new ErrorDataResult<CarImage>(Messages.NotFoundImage);
            
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {

            var result = GetByImageId(carImage.Id);
            if (!result.Success) 
            {
                return result;
            }
            // carImage.ImagePath = _fileHelper.Update(file, carImage.ImagePath, PathConstants.ImagesPath);
            carImage.ImagePath = _fileHelper.Update(file, result.Data.ImagePath, PathConstants.ImagesPath);
            carImage.CarId = result.Data.CarId;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.UpdatedCarImage);
        }

        private IResult CheckIfCarImageLimit(int  carId)
        {
            //bir carin maxsimum bes sekili ola biler
           var imagesCount =  _carImageDal.GetAll(ci=>ci.CarId==carId).Count;
            if (imagesCount>=5)
            {
                return new ErrorResult(Messages.ImagesLimitExceeded);
            }
            return  new SuccessResult();

        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            //yalanci datadir
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { Id =1 , CarId = carId , ImagePath = "DefaultImage.jpg"});
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        private IDataResult<CarImage> CheckCarImage(int carId)
        {
            var result = _carImageDal.Get(ci => ci.CarId == carId);
            if (result==null)
            {
                return new ErrorDataResult<CarImage>(Messages.DefaultImage);
            }
            return new SuccessDataResult<CarImage>(result);

        }

    
    }
}
