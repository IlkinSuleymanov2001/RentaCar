using Core.DataAccess.EntityFramework;
using DataAccess.Abstrasts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concrets;
using Entities.DTOs.Customer;
using Entities.DTOs.User;


namespace DataAccess.Concretes.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersDetail()
        {
            using (RentACarContext context = new())
            {
                var result =( from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName=  c.CompanyName,
                                 User = new UserForAddDto
                                 { 
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Email = u.Email    
                                 } 

                           
                             });

                return result.ToList();

            }
        }
    }
}
