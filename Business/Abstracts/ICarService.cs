using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrets;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICarService 
    {

        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IDataResult<Car> GetById(int id);
        IResult Delete(Car entity);
        IResult Update(Car entity);
       
    }
}
