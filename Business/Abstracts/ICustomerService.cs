using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrets;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public  interface  ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer entity);
        IDataResult<Customer> GetById(int id);
        IResult Delete(Customer entity);
        IResult Update(Customer entity);

    }
}
