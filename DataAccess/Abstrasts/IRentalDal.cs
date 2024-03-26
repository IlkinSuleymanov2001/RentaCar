using Core.DataAccess;
using Entities.Concrets;
using Entities.DTOs.Rental;
namespace DataAccess.Abstrasts
{
    public interface IRentalDal : IEntityRepository<Rental>
       
    {
      List<RentalDetailDto> GetRentalsDetail();


    }
}
