using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrets;
using Entities.DTOs.Rental;


namespace Business.Abstracts
{
    public interface  IRentalService 
    {

        IDataResult<List<Rental>> GetAll();
        IResult Add(RentalForAddDto entity);
        IDataResult<Rental> GetById(int id);
        IResult Delete(Rental entity);
        IResult Update(Rental entity);
        IDataResult<List<RentalDetailDto>> GetRentalsDetail();
    }
    
}
