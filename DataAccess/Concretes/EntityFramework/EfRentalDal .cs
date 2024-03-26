using Core.DataAccess.EntityFramework;
using DataAccess.Abstrasts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concrets;
using Entities.DTOs;
using Entities.DTOs.Car;
using Entities.DTOs.Customer;
using Entities.DTOs.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        

        public List<RentalDetailDto> GetRentalsDetail()
        {
            using (RentACarContext context = new())
            {

                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cs in context.Customers
                             on r.CustomerId equals cs.Id
                             select new RentalDetailDto {
                                RentDate = r.RentDate,
                                ReturnDate = r.ReturnDate,
                                Car = new CarDetailDto
                                {
                                    CarName = c.CarName,
                                    DailyPrice = c.DailyPrice,
                                    Description = c.Description,
                                    ModelYear = c.ModelYear,                      
                                },
                                Customer = new CustomerDetailDto
                                { 
                                    CompanyName=  cs.CompanyName,
                                
                                }
                             };
               return  result.ToList();




            }
        }
    }
}
