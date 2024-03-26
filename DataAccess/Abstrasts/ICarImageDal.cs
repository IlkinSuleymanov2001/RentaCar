using Core.DataAccess;
using Entities.Concrets;
using Entities.DTOs.CarImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstrasts
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImageDetailDto> GetCarImagesDetail();
    }
}
