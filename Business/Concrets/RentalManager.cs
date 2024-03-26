using Business.Abstracts;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstrasts;
using Entities.Concrets;
using Entities.DTOs.Rental;

namespace Business.Concrets
{
    public class RentalManager : IRentalService
    {

    private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal dao)
        {
            _rentalDal = dao;
        }

        public IResult Add(RentalForAddDto entity)
        {

            var result = BusinessRule.Run(CheckIfCarUsing(entity.CarId));
            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(new Rental 
            {
                CarId = entity.CarId,
                CustomerId = entity.CustomerId,
                RentDate = entity.RentDate,
                ReturnDate = entity.ReturnDate
            });
            return new SuccessResult("successfully added..");
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
           var rentals=  _rentalDal.GetAll();
           return new SuccessDataResult<List<Rental>>(rentals);
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetail()
        {
            var rentalsDetail = _rentalDal.GetRentalsDetail();
            return new SuccessDataResult<List<RentalDetailDto>>(rentalsDetail);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult( "updated succes operation");
        }

        private IResult CheckIfCarUsing(int carId)
        {
            // return date null-dusa car isdifade olunur 
         var result = _rentalDal.GetAll(r => r.CarId == carId
          && r.ReturnDate == null).Any();
            if (result)
            {
                return new ErrorResult("the car using  other by customer");
            }
            return new SuccessResult();

        }
    }
}
