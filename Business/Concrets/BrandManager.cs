using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstrasts;
using Entities.Concrets;
using Entities.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrets
{
    public class BrandManager : IBrandService
    {

    private readonly IBrandDal _brandDao;

        public BrandManager(IBrandDal brandDao)
        {
            _brandDao = brandDao;
        }

        public IResult Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BrandDto>> GetDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
