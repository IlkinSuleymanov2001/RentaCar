using Core.DataAccess;
using Entities.Concrets;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstrasts
{
    public interface ICarDal : IEntityRepository<Car>
    { 
    
    }
}
