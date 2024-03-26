using Core.DataAccess.EntityFramework;
using DataAccess.Abstrasts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concrets;
using Entities.DTOs.CarImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImagesDetail()
        {
            throw new NotImplementedException();
        }
    }
}
