using Core.DataAccess.EntityFramework;
using DataAccess.Abstrasts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concrets;
using Entities.DTOs;


namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarDao : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
  
            
       
    }
}
