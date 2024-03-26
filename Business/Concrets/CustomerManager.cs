using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstrasts;
using Entities.Concrets;
using Entities.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrets
{
    public class CustomerManager : ICustomerService
    {

    private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult("added status success");
        }

        public IResult Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CustomerDetailDto>> GetDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer entity)
        {
           _customerDal.Update(entity);
            return new SuccessResult("succes update status..");
        }
    }
}
