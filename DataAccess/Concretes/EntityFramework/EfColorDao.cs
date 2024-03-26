using Core.DataAccess.EntityFramework;
using DataAccess.Abstrasts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfColorDao : EfEntityRepositoryBase<Color, RentACarContext>,  IColorDal
    {
       
    }
}
